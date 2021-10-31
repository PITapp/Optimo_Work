using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RadzenAngularFileUpload.Controllers
{

    // [Route("upload")]

    [DisableRequestSizeLimit]

    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload/single")]
        public async Task<ActionResult> SingleAsync(IFormFile file)
        {
            try
            {
                await UploadFile(file);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("upload/bild/base/{zielName}")]
        public async Task<ActionResult> Single2Async(IFormFile file, string zielName)
        {
            try
            {
                await UploadFileBilderBase(file, zielName);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("upload/dokumente/{zielName}")]
        public async Task<ActionResult> Single3Async(IFormFile file, string zielName)
        {
            try
            {
                await UploadFileDokumente(file, zielName);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("upload/multiple")]
        public async Task<IActionResult> MultipleAsync(IFormFile[] files)
        {
            try
            {
                foreach (IFormFile file in files)
                {
                    await UploadFile(file);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\medien\upload";
                var uploadPath = _environment.WebRootPath.Substring(0, _environment.WebRootPath.IndexOf("sindarela") + 9) + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fullPath = Path.Combine(uploadPath, file.FileName);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))

                    await file.CopyToAsync(fileStream);
            }
        }

        public async Task UploadFileBilderBase(IFormFile file, string zielName)
        {
            if (file != null && file.Length > 0)
            {
                // Pfad = E:\wwwroot\pitapp.at\sindarela\webapp\wwwroot\upload\bilder\base
                
                var imagePath = @"\medien\upload\bilder\base";
                //var uploadPath = _environment.WebRootPath + imagePath;
                //var uploadPath = @"E:\wwwroot\pitapp.at\sindarela\webapp\wwwroot" + imagePath;
                //var uploadPath = @"E:\wwwroot\pitapp.at\sindarela\medien" + imagePath;

                var uploadPath = _environment.WebRootPath.Substring(0, _environment.WebRootPath.IndexOf("sindarela") + 9) + imagePath;

                // ---------- Text in Datei ausgeben ------------------------
                // Create a string array with the lines of text
                //string[] lines = { "First line", zielName, uploadPath };
                // Set a variable to the Documents path.
                //string docPath = uploadPath;  //   Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Write the string array to a new file named "WriteLines.txt".
                //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
                //{
                //    foreach (string line in lines)
                //        outputFile.WriteLine(line);
                //}

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fullPath = Path.Combine(uploadPath, zielName);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))

                    await file.CopyToAsync(fileStream);
            }
        }

        public async Task UploadFileDokumente(IFormFile file, string zielName)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\medien\upload\dokumente";
                var uploadPath = _environment.WebRootPath.Substring(0, _environment.WebRootPath.IndexOf("sindarela") + 9) + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fullPath = Path.Combine(uploadPath, zielName);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))

                    await file.CopyToAsync(fileStream);
            }
        }
    }
}