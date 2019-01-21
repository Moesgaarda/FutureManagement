using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Dtos.FileDtos;

namespace API.Data
{
    public interface IItemTemplateRepository
    {
        Task<ItemTemplate> GetItemTemplate(int id);
        Task<List<ItemTemplate>> GetItemTemplates();
        Task<bool> AddItemTemplate(ItemTemplate template);
        Task<bool> EditItemTemplate(ItemTemplate template);
        Task<bool> DeleteItemTemplate(ItemTemplate template);
        Task<bool> AddPropertyName(ItemPropertyName propertyTemplate);
        Task<bool> AddUnitType(UnitType unitType);
        Task<bool> AddTemplateCategory(ItemTemplateCategory category);
        Task<bool> ActivateItemTemplate(ItemTemplate template);
        Task<bool> DeactivateItemTemplate(ItemTemplate template);
        Task<ItemPropertyName> GetPropertyName(int id);
        Task<List<ItemPropertyName>> GetPropertyNames();
        Task<List<TemplateFileName>> GetFiles(int id);
        Task<List<ItemTemplateCategory>> GetTemplateCategories();
        Task<List<UnitType>> GetUnitTypes();
    }
}
