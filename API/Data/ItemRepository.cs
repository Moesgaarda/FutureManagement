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

        public async Task<bool> ActivateItem(Item item)
        {
            item.IsActive = true;
            _context.Items.Update(item);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AddItem(ItemForAddDto item)
        {
            // await _context.Items.AddAsync(item);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeactivateItem(Item item)
        {
            item.IsActive = false;
            _context.Items.Update(item);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteItem(Item item)
        {
            _context.Items.Remove(item);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EditItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Item>> GetActiveItems(List<Item> activeItemList)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Item>> GetInactiveItems(List<Item> archivedItemList)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Item>> GetAllItems(List<Item> itemList)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Item> GetItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Item> ShowDetails(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}