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
        Task<bool> ActivateItemTemplate(ItemTemplate template);
        Task<bool> DeactivateItemTemplate(ItemTemplate template);
        Task<List<TemplateFileName>> GetFiles(int id);
    }
}
