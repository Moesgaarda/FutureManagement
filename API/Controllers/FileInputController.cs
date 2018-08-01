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
        public async Task<IActionResult> UploadFiles(List<IFormFile> files, string originPath){
            if(files.Count == 0 ||files == null){
                ModelState.AddModelError("File Error","No files selected");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            foreach(IFormFile file in files){
                if(file == null || file.Length == 0){
                    ModelState.AddModelError("File Error", "No file selected");
                }
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            originPath, file.Name);
                using(var stream = new FileStream(path, FileMode.Create)){
                    await file.CopyToAsync(stream);
                }
                
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