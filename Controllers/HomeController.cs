using CDN.ITEGAMAX._4._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CDN.ITEGAMAX._4._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>? _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("api/uploadmedia")]
        public async Task<IActionResult> UploadFile()
        {
            string? _currentfilepath = null;
            //The size of the file is limited to 1 MB (indicated in bytes).
            var _fileSizeLimit = 1048576;
            string[] _fileMimetypes = { "image/png", "image/jpg", "image/jpeg" };
            var _upploaddirectory = "";

            var _upploaddirectorywwroot = CLCustAppsettings.IMAGE_WWWROOT;



            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var _file = HttpContext.Request.Form.Files[0];
                string _fileContentType = _file.ContentType;
                string _fileName = _file.FileName;
                string _fileExtension = Path.GetExtension(_file.FileName);

                const string directoryu = "udirectory";
                string headerValueDirectory = HttpContext.Request.Form[directoryu]!;

                if (!string.IsNullOrEmpty(headerValueDirectory))
                {
                    _upploaddirectory = Path.Combine(_upploaddirectorywwroot!, headerValueDirectory!);
                }

                if (!Directory.Exists(_upploaddirectory))
                {
                    Directory.CreateDirectory(_upploaddirectory);
                }


                try
                {
                    if (_file == null || _file.Length == 0)
                    {
                        return BadRequest("No file uploaded.");
                    }

                    #region Size validation
                    if (_file.Length > _fileSizeLimit)
                    {
                        return BadRequest("No file uploaded 1. The file is too large");
                    }
                    #endregion

                    #region Validate File Type
                    var permittedExtensions = new[] { ".jpg", ".png", ".jpeg" };
                    var extension = Path.GetExtension(_file.FileName).ToLowerInvariant();
                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                    {
                        return BadRequest("No file uploaded 2.Disallowed file type.");
                    }
                    #endregion

                    #region Use Anti-Virus Scanning
                    //// Pseudo-code for anti-virus scanning
                    //bool isSafe = AntiVirus.Scan(file);
                    //if (!isSafe)
                    //{
                    //    return BadRequest("File detected as unsafe.");
                    //}
                    #endregion

                    #region Upload To Cloud Storage
                    //// This is a simplified example for Azure Blob Storage
                    //BlobClient blobClient = new BlobClient(connectionString, containerName, blobName);
                    //await blobClient.UploadAsync(stream);
                    #endregion

                    var path = Path.Combine(Directory.GetCurrentDirectory(), _upploaddirectory, _fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await _file.CopyToAsync(stream);
                    }
                    _currentfilepath = path;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "File upload failed: " + ex.Message);
                }
            }

            return Ok(new { FilePath = _currentfilepath }); // Return the file path
        }
    }
}
