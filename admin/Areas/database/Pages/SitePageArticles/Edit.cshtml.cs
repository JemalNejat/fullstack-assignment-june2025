using ADMIN.ITEGAMAX._4._0.App_Data;
using ADMIN.ITEGAMAX._4._0.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ADMIN.ITEGAMAX._4._0.Models;
using System;
using System.Net.Http.Headers;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SitePageArticles
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;
        private string uri = CLCustAppsettings.IMAGE_SERVICES_PATH!;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StPageArticle StPageArticle { get; set; }

        public List<StPage> StPages { get; set; } = new List<StPage>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch all StPage records
            StPages = await _db.StPages.ToListAsync();

            var article = await _db.StPageArticles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            StPageArticle = article;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                StPages = await _db.StPages.ToListAsync();
                return Page();
            }

            int id = StPageArticle.StArticleId;
            var existing = await _db.StPageArticles.FindAsync(id);
            if (existing == null) return NotFound();

            // Here we check if the user uploaded an image using FilePond
            if (!string.IsNullOrEmpty(Request.Form["filepond"]))
            {
                // The image was uploaded and stored in filePondJson — now this read the FilePond JSON data from the form
                string filePondJson = Request.Form["filepond"];

                // Next we convert the JSON string into a usable object
                JObject jsonObj = JObject.Parse(filePondJson);

                // Here we get the base64-encoded file data (the actual image)
                string base64String = jsonObj["data"]?.ToString();

                //  We extract the original name of the uploaded file
                string originalFileName = jsonObj["name"]?.ToString();

                // We get the file extension (.jpg or .png, etc.)
                string fileExtension = Path.GetExtension(originalFileName);

                // Create a new random name for the uploaded file
                string newFileName = $"itegamax_{Guid.NewGuid()}{fileExtension}";

                // Convert the base64 string into a byte array (real file data)
                byte[] fileBytes = Convert.FromBase64String(base64String);

                // Here we prepare the image and form fields to send to the upload API
                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(fileBytes);

                //  Set the file type
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                //  Add the API key in the headers
                fileContent.Headers.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);

                // Attach directory name and file to the form
                form.Add(new StringContent("article_images"), "udirectory");
                form.Add(fileContent, "formFile", newFileName);

                // Create a new HTTP client to talk to the image upload server
                var httpClient = new HttpClient { BaseAddress = new Uri(uri) };

                // Add the API key again (this time to request headers)
                httpClient.DefaultRequestHeaders.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);

                // Send the image to the image server
                var response = await httpClient.PostAsync("/api/uploadmedia", form);

                //  If something went wrong, throw an error with details
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Image upload failed: {await response.Content.ReadAsStringAsync()}");

                //  Save the new image name and alignment to the existing article
                existing.ArticlePicture = newFileName;
                existing.ArticlePictureAlign = StPageArticle.ArticlePictureAlign;

                // Update the "last updated" timestamp
                existing.Articleupdatedate = DateTime.Now;
            }
            else
            {
                // If no image was uploaded, update the text fields instead
                existing.Articletitle = StPageArticle.Articletitle;
                existing.Articlesubtitle = StPageArticle.Articlesubtitle;
                existing.Articletext = StPageArticle.Articletext;
                existing.StPageId = StPageArticle.StPageId;
                existing.ArticlestStatus = StPageArticle.ArticlestStatus;
                existing.ArticlePictureLinktitle = StPageArticle.ArticlePictureLinktitle;
                existing.ArticlePictureLinkurl = StPageArticle.ArticlePictureLinkurl;
                existing.ArticlePictureLinktarget = StPageArticle.ArticlePictureLinktarget;
                existing.ArticlePosition = StPageArticle.ArticlePosition;

                // Update the "last updated" timestamp
                existing.Articleupdatedate = DateTime.Now;
            }

            // Save all changes to the database
            await _db.SaveChangesAsync();

            // Redirect the user back to the View page for the article
            return RedirectToPage("View", new { id = id });

        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var article = await _db.StPageArticles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _db.StPageArticles.Remove(article);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
