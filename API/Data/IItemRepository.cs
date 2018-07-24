using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Data
{
    public interface IItemRepository
    {
        Task<List<Item>> GetActiveItems(List<Item> activeItemList);  
        Task<List<Item>> GetInactiveItems(List<Item> archivedItemList);
        Task<List<Item>> GetAllItems(List<Item> itemList);
        Task<Item> GetItem(int id);
        Task<bool> AddItem(Item item);
        Task<bool> EditItem(Item item);
        Task<bool> DeleteItem(Item item);
        Task<bool> ActivateItem(Item item);
        Task<bool> DeactivateItem(Item item);

    }
}