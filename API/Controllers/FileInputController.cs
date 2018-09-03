using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadFiles(){
            List<int> fileIds = new List<int>();
            bool isUploaded;
            foreach (IFormFile file in Request.Form.Files){
                if (file == null || file.Length == 0){
                    return NoContent();
                }

                var fileHash = MD5.Create().ComputeHash(file.OpenReadStream());
                isUploaded = await _repo.IsFileUploaded(fileHash);
                if(isUploaded){
                    fileIds.Add(await _repo.GetFileId(fileHash));
                }
                else{
                    using(var stream = new FileStream(file.FileName, FileMode.Create)){
                        await file.CopyToAsync(stream);
                    }
                    FileData fileToAdd = new FileData(){
                        FileHash = fileHash,
                        FilePath = file.FileName
                    };
                    fileIds.Add(await _repo.AddFile(fileToAdd));
                }
            }
            return Ok(fileIds);
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var factories = context.ValueProviderFactories;
            factories.RemoveType<FormValueProviderFactory>();
            factories.RemoveType<JQueryFormValueProviderFactory>();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }    
}