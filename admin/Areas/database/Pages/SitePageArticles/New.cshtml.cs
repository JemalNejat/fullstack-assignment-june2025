using ADMIN.ITEGAMAX._4._0.App_Data;
using ADMIN.ITEGAMAX._4._0.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ADMIN.ITEGAMAX._4._0.Models;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SitePageArticles
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;
        private string uri = CLCustAppsettings.IMAGE_SERVICES_PATH!;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StPageArticle StPageArticle { get; set; }

        public List<StPage> StPages { get; set; } = new List<StPage>();

        public async Task<IActionResult> OnGetAsync()
        {
            StPages = await _db.StPages.ToListAsync();
            StPageArticle = new StPageArticle
            {
                Articlecreateddate = DateTime.Now,
                Articleupdatedate = DateTime.Now,
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                StPages = await _db.StPages.ToListAsync();
                return Page();
            }

            // If image is being uploaded
            if (!string.IsNullOrEmpty(Request.Form["filepond"]))
            {
                string filePondJson = Request.Form["filepond"];
                JObject jsonObj = JObject.Parse(filePondJson);

                string base64String = jsonObj["data"]?.ToString();
                string originalFileName = jsonObj["name"]?.ToString();
                string fileExtension = Path.GetExtension(originalFileName);
                string newFileName = $"itegamax_{Guid.NewGuid()}{fileExtension}";

                byte[] fileBytes = Convert.FromBase64String(base64String);

                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                fileContent.Headers.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);

                form.Add(new StringContent("article_images"), "udirectory");
                form.Add(fileContent, "formFile", newFileName);

                var httpClient = new HttpClient { BaseAddress = new Uri(uri) };
                httpClient.DefaultRequestHeaders.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);

                var response = await httpClient.PostAsync("/api/uploadmedia", form);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Image upload failed: {await response.Content.ReadAsStringAsync()}");

                StPageArticle.ArticlePicture = newFileName;
                StPageArticle.ArticlePictureAlign = StPageArticle.ArticlePictureAlign;
                StPageArticle.Articlecreateddate = DateTime.Now;
                StPageArticle.Articleupdatedate = DateTime.Now;

                _db.StPageArticles.Add(StPageArticle);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                // No image, only article fields
                StPageArticle.Articlecreateddate = DateTime.Now;
                StPageArticle.Articleupdatedate = DateTime.Now;

                _db.StPageArticles.Add(StPageArticle);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
        }
    }
}