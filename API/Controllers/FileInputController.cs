using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.FileDtos;
using API.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class FileInputController : Controller
    {
        private readonly DataContext _context;
        private readonly IFileInputRepository _repo;

        public FileInputController(IFileInputRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpPost("uploadfiles", Name = "UploadFiles")]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadFiles()
        {
            List<int> fileIds = new List<int>();
            bool isUploaded;
            StringValues origin;
            Request.Form.TryGetValue("origin", out origin);


            string path = origin.ToArray()[0] + "/";
            foreach (IFormFile file in Request.Form.Files)
            {
                if (file == null || file.Length == 0)
                {
                    continue;
                }

                var fileHash = MD5.Create().ComputeHash(file.OpenReadStream());
                isUploaded = await _repo.IsFileUploaded(fileHash);
                if (isUploaded)
                {
                    fileIds.Add(await _repo.GetFileId(fileHash));
                }
                else
                {
                    var fileName = BitConverter.ToString(fileHash).Replace("-", string.Empty);
                    using (var stream = new FileStream(path + fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    FileData fileToAdd = new FileData()
                    {
                        FileHash = fileHash,
                        FilePath = path + fileName
                    };
                    fileIds.Add(await _repo.AddFile(fileToAdd));
                }
            }
            return Ok(fileIds);
        }

        [HttpGet("downloadfile", Name = "DownloadFile")]
        public async Task<IActionResult> Download(int id)
        {
            var fileData = await _repo.GetFile(id);
            var bytes = System.IO.File.ReadAllBytes(fileData.FilePath);
            return new FileContentResult(bytes, MediaTypeNames.Application.Octet);
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