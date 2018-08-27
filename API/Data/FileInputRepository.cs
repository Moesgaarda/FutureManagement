using System.Threading.Tasks;
using API.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class FileInputRepository : IFileInputRepository
    {
        private readonly DataContext _context;
        public FileInputRepository (DataContext context){
            _context = context;
        }
        public async Task<int> AddFile(FileData file)
        {
            var fileToAdd = await _context.AddAsync(file);
            return fileToAdd.Entity.Id;
        }

        public async Task<int> GetFileId(byte[] fileHash)
        {
            FileData file = await _context.FileData.FirstOrDefaultAsync(x => x.FileHash == fileHash);
            return file.Id;                        
        }

        public async Task<bool> IsFileUploaded(byte[] fileHash)
        {
            return await _context.FileData.FirstOrDefaultAsync(x => x.FileHash == fileHash) == null; 
        }
    }
}