using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UnitTypeRepository : IUnitTypeRepository
    {
        private DataContext _context;

        public UnitTypeRepository(DataContext dbContext){
            this._context = dbContext;
        }

        public async Task<bool> AddUnitType(UnitType unitType)
        {
            await _context.UnitTypes.AddAsync(unitType);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<List<UnitType>> GetUnitTypes()
        {
            return await _context.UnitTypes.ToListAsync();
        }

        public async Task<UnitType> GetUnitType(int id)
        {
            return await _context.UnitTypes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> EditUnitType(UnitType unitType)
        {
            var unitTypeToChange = _context.UnitTypes.FirstOrDefaultAsync(x => x.Id == unitType.Id);
            _context.Entry(unitTypeToChange).CurrentValues.SetValues(unitType);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}