using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface ITemplateCategoryRepository
    {
        Task<List<ItemTemplateCategory>> GetCategories();
        Task<ItemTemplateCategory> GetCategory(int id);
        Task<bool> EditCategory(ItemTemplateCategory oldCategory, ItemTemplateCategory newCategory);
        Task<bool> AddCategory(ItemTemplateCategory category);
    }
}