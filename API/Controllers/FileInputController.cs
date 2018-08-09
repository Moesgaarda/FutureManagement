using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class FileInputController : Controller
    {
        private readonly DataContext _context;
        public FileInputController(DataContext context){
            _context = context;
        }

        [HttpPost("uploadfiles", Name = "UploadFiles")]
        public async Task<IActionResult> UploadFiles(){
            foreach (IFormFile file in Request.Form.Files){
                if (file == null || file.Length == 0){
                    return NoContent();
                }

                var stream = file.OpenReadStream();
                //TODO file should be uploaded here, but alas it is not.

                var fileStream = new FileStream("C:\\", FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
                fileStream.Dispose();
            }
            return StatusCode(201);
        }
        [HttpGet]
        public async Task<IActionResult> Download(string filename){
            if(filename == null || filename.Length == 0){
                ModelState.AddModelError("File Error", "filename is not present");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, Path.GetFileName(path));
        }
    }
}