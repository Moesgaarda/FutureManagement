using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface ITemplatePropertyRepository
    {
        Task<List<ItemPropertyName>> GetProperties();
        Task<ItemPropertyName> GetProperty(int id);
        Task<bool> EditProperty(ItemPropertyName oldProperty, ItemPropertyName newProperty);
        Task<bool> AddProperty(ItemPropertyName property);
        bool DuplicateExists(string name);
    }
}