using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TemplateCategoryRepository : ITemplateCategoryRepository
    {
        private DataContext _context;

        public TemplateCategoryRepository(DataContext dbContext){
            this._context = dbContext;
        }

        public async Task<bool> AddCategory(ItemTemplateCategory category)
        {
            await _context.TemplateCategories.AddAsync(category);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<List<ItemTemplateCategory>> GetCategories()
        {
            return await _context.TemplateCategories.ToListAsync();
        }

        public async Task<ItemTemplateCategory> GetCategory(int id)
        {
            return await _context.TemplateCategories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> EditCategory(ItemTemplateCategory oldCategory, ItemTemplateCategory newCategory)
        {
            var result = await _context.TemplateCategories.SingleOrDefaultAsync(x => x.Id == oldCategory.Id);
            if(result != null){
                result.Name = newCategory.Name;
                return await _context.SaveChangesAsync() > 0;
            }
        return false;
        }

        public bool DuplicateExists(string name){
            name.ToLower();
            name.Normalize();
            Task<bool> exists = _context.ItemTemplateCategories.AnyAsync(x => x.Name.ToLower().Normalize() == name);
            return exists.Result;
        }
    }
}