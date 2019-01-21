using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public class UnitTypeRepository : IUnitTypeRepository
    {
        private DataContext _dbContext;

        public UnitTypeRepository(DataContext dbContext){
            this._dbContext = dbContext;
        }

        public Task<bool> AddUnitType(UnitType unitType)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditUnitType(UnitType unitType)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UnitType>> GetUnitTypes()
        {
            throw new System.NotImplementedException();
        }

        public Task<UnitType> GetUnitType(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}