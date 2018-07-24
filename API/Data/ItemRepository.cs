using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Data
{
    public class ItemRepository : IItemRepository
    {

        private readonly DataContext _context;

        public ItemRepository(DataContext context){
            this._context = context;
}

        public Task<bool> ActivateItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddItem(ItemForAddDto item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeactivateItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Item>> GetallActiveItems(List<Item> activeItemList)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Item>> GetAllInactiveItems(List<Item> archivedItemList)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Item>> GetAllItems(List<Item> itemList)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> ShowDetails(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}