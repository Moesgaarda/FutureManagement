using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class FileInputController : Controller
    {
        private readonly DataContext _context;
        private readonly IFileInputRepository _repo;
        public FileInputController(IFileInputRepository repo, DataContext context){
            _repo = repo;
            _context = context;
        }

        [HttpPost("uploadfiles", Name = "UploadFiles")]
        public async Task<IActionResult> UploadFiles(){ 
            foreach (IFormFile file in Request.Form.Files){
                if (file == null || file.Length == 0){
                    return NoContent();
                }

                var fileHash = MD5.Create().ComputeHash(file.OpenReadStream());

                if(_repo.IsFileUploaded(fileHash).Result){
                    return Ok(_repo.GetFileId(fileHash));
                }
                else{
                    using(var stream = new FileStream(file.FileName, FileMode.Create)){
                        await file.CopyToAsync(stream);
                    }
                    FileData fileToAdd = new FileData(){
                        FileHash = fileHash,
                        FilePath = file.FileName
                    };
                    int fileId = await _repo.AddFile(fileToAdd);
                    return Ok(fileId);
                }
            }
            return BadRequest("File upload failed.");
        }
    }
}