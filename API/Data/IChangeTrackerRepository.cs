using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IChangeTrackerRepository
    {
        Task<List<Change>> GetAllChanges();
        Task<List<Change>> GetChanges(int id);
    }
}