using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http.Headers;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages
{
    public class testmediauploadModel : PageModel
    {
        public void OnGet()
        {
        }

        private string uri = CLCustAppsettings.IMAGE_SERVICES_PATH!;
        private byte[]? mediafiledata { get; set; }
        private string? mediafilename;
       
        public async Task<IActionResult> OnPostAsync()
        {

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                foreach (var _formFile in HttpContext.Request.Form.Files)
                {
                    //if (_formFile.Name == "ad_pkg_md_imagefile_" + i)
                    //{
                        string _fileextension = Path.GetExtension(_formFile.FileName);
                    mediafilename = "itegamax_" + Guid.NewGuid().ToString() + _fileextension;

                        using (var memoryStream = new MemoryStream())
                        {
                            await _formFile.CopyToAsync(memoryStream);
                        mediafiledata = memoryStream.ToArray();
                        }

                    //}
                }
            }



            using var form = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(mediafiledata!);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            fileContent.Headers.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);
            form.Add(new StringContent("adimages"), "udirectory");
            form.Add(fileContent, "formFile", mediafilename!);

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(uri)
            };

            httpClient.DefaultRequestHeaders.Add("XApiKey", CLCustAppsettings.XAPIKEY_IMAGES);

            var response = await httpClient.PostAsync($"/api/uploadmedia", form);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            return Page();


        }
       
    
    }
}
