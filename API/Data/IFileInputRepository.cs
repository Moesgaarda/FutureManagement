using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IFileInputRepository
    {
        Task<bool> IsFileUploaded(byte[] fileHash);
        Task<int> AddFile(FileData file);
        Task<int> GetFileId(byte[] fileHash);
    }
}