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

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SitePages
{

    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;
        private string uri = CLCustAppsettings.IMAGE_SERVICES_PATH!;

        [BindProperty]
        public StPage EditPage { get; set; }

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditPage = await _db.StPages.FindAsync(id);

            if (EditPage == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _db.Attach(EditPage).State = EntityState.Modified;

            if (!string.IsNullOrEmpty(HttpContext.Request.Form["filepond"]))
            {
                string _file = HttpContext.Request.Form["filepond"]!;

                JObject jsonObj = JObject.Parse(_file);

                ImageInfo _uploaffile = new ImageInfo
                {
                    Id = (string)jsonObj["id"]!,
                    Name = (string)jsonObj["name"]!,
                    Type = (string)jsonObj["type"]!,
                    Size = (int)jsonObj["size"]!,
                    Data = (string)jsonObj["data"]!,
                    DataBytes = Convert.FromBase64String((string)jsonObj["data"]!)
                };


                _uploaffile.FileExtension = Path.GetExtension(_uploaffile.Name);
                _uploaffile.NewName = "itegamax_" + Guid.NewGuid().ToString() + _uploaffile.FileExtension;
                _uploaffile.FileUploadPath = EditPage.Pageurlid.Replace("/","");

                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(_uploaffile.DataBytes!);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                fileContent.Headers.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);
                form.Add(new StringContent(_uploaffile.FileUploadPath), "udirectory");
                form.Add(fileContent, "formFile", _uploaffile.NewName!);

                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(uri)
                };

                httpClient.DefaultRequestHeaders.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);

                var response = await httpClient.PostAsync($"/api/uploadmedia", form);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                switch (Request.Form["imageType"])
                {
                    case "1":
                        EditPage.Pagetopbannerpic = _uploaffile.NewName;
                        EditPage.Pagetopbannertitle = Request.Form["iamgetitle"];
                        EditPage.Pagetopbannersubtitle = Request.Form["iamgesubtitle"];
                        EditPage.Pagetopbannertext = Request.Form["iamgetext"];
                        break;
                    case "2":
                        EditPage.Pagemediumbannerpic = _uploaffile.NewName;
                        EditPage.Pagemediumbannertitle = Request.Form["iamgetitle"];
                        EditPage.Pagemediumbannersubtitle = Request.Form["iamgesubtitle"];
                        EditPage.Pagemediumbannertext = Request.Form["iamgetext"];

                        break;
                    case "3":
                        EditPage.Pagesmallbannerpic = _uploaffile.NewName;
                        EditPage.Pagesmallbannertitle = Request.Form["iamgetitle"];
                        EditPage.Pagesmallbannersubtitle = Request.Form["iamgesubtitle"];
                        EditPage.Pagesmallbannertext = Request.Form["iamgetext"];
                        break;
                }

                try
                {
                    EditPage.Pageupdateddate = DateTime.Now;    
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(EditPage.PageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }


                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(EditPage.PageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return Redirect("View?id=" + EditPage.PageId);
        }

        private bool PageExists(int id)
        {
            return _db.StPages.Any(e => e.PageId == id);
        }
    }
}
