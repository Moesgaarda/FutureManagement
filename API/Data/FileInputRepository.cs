using System.Threading.Tasks;
using API.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using API.Dtos.FileDtos;

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
            var fileToAdd = await _context.FileData.AddAsync(file);
            await _context.SaveChangesAsync();
            return fileToAdd.Entity.Id;
        }

        public async Task<FileData> GetFile(int id)
        {
            FileData fileData = await _context.FileData.Where(x => x.Id == id).FirstOrDefaultAsync();
            return fileData;
        }

        public async Task<int> GetFileId(byte[] fileHash)
        {
            FileData file = await _context.FileData.FirstOrDefaultAsync(x => x.FileHash == fileHash);
            return file.Id;                        
        }

        public async Task<bool> IsFileUploaded(byte[] fileHash)
        {
            FileData file = await _context.FileData.FirstOrDefaultAsync(x => x.FileHash == fileHash);
            
            if (file == null)
            {
                return false;
            }
            return true;
        }
        
    }
}
