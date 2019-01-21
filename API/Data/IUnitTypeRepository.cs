using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IUnitTypeRepository
    {
        Task<List<UnitType>> GetAllUnitTypes();
        Task<UnitType> GetUnitType(int id);
        Task<bool> EditUnitType(UnitType unitType);
        Task<bool> AddUnitType(UnitType unitType);
    }
}