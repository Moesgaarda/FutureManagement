using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TemplatePropertyRepository : ITemplatePropertyRepository
    {
        private DataContext _context;

        public TemplatePropertyRepository(DataContext dbContext){
            this._context = dbContext;
        }

        public async Task<bool> AddProperty(ItemPropertyName propertyName)
        {
            await _context.ItemPropertyNames.AddAsync(propertyName);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<List<ItemPropertyName>> GetProperties()
        {
            return await _context.ItemPropertyNames.ToListAsync();
        }

        public async Task<ItemPropertyName> GetProperty(int id)
        {
            return await _context.ItemPropertyNames.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> EditProperty(ItemPropertyName oldPropertyName, ItemPropertyName newPropertyName)
        {
            var result = await _context.ItemPropertyNames.SingleOrDefaultAsync(x => x.Id == oldPropertyName.Id);
            if(result != null){
                result.Name = newPropertyName.Name;
                return await _context.SaveChangesAsync() > 0;
            }
        return false;
        }

        public bool DuplicateExists(string name){
            name.ToLower();
            name.Normalize();
            Task<bool> exists = _context.ItemPropertyNames.AnyAsync(x => x.Name.ToLower().Normalize() == name);
            return exists.Result;
        }
    }
}