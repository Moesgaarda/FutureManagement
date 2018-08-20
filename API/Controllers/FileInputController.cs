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
                using(var stream = new FileStream(file.FileName, FileMode.Create)){
                    await file.CopyToAsync(stream);
                }
            }
            return StatusCode(201);
        }
    }
}