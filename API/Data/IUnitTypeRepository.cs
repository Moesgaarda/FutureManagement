using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IUnitTypeRepository
    {
        Task<List<UnitType>> GetUnitTypes();
        Task<UnitType> GetUnitType(int id);
        Task<bool> EditUnitType(UnitType oldUT, UnitType newUT);
        Task<bool> AddUnitType(UnitType unitType);
    }
}
