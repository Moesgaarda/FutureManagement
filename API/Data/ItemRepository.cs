using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data {
    public class ItemRepository : IItemRepository {

        private readonly DataContext _context;

        public ItemRepository (DataContext context) {
            this._context = context;
        }

        public async Task<bool> ActivateItem (Item item) {
            item.IsActive = true;
            _context.Items.Update (item);
            var result = await _context.SaveChangesAsync ();

            return result > 0;
        }

        public async Task<bool> AddItem (Item item) {
            item.Template = await _context.ItemTemplates.FirstOrDefaultAsync (x => x.Id == item.Template.Id);
            item.Order = await _context.Orders.FirstOrDefaultAsync (x => x.Id == item.Order.Id);
            item.CreatedBy = await _context.Users.FirstOrDefaultAsync (x => x.Id == item.CreatedBy.Id);

            foreach (var prop in item.Properties) {
                prop.PropertyName = await _context.ItemPropertyNames.FirstOrDefaultAsync (x => x.Id == prop.PropertyName.Id);
            }

            await _context.Items.AddAsync(item);
            int result = await _context.SaveChangesAsync ();

            return result > 0;
        }

        public async Task<bool> DeactivateItem (Item item) {
            item.IsActive = false;
            _context.Items.Update (item);
            var result = await _context.SaveChangesAsync ();

            return result > 0;
        }

        public async Task<bool> HasDependencies(Item item){
            return await _context.ItemItemRelations.AnyAsync(x => x.PartId == item.Id);        
        }

        public async Task<bool> DeleteItem (Item item) {
            _context.Entry(item).Collection(x => x.Properties)
                .Query()
                .Include(x => x.PropertyName)
                .Load();
            _context.ItemPropertyDescriptions.RemoveRange(item.Properties);
            _context.Items.Remove(item);
            int result = await _context.SaveChangesAsync ();
            return result > 0;
        }

        public async Task<bool> EditItem (Item item) {
            var itemToChange = await _context.Items.FirstAsync (x => x.Id == item.Id);
            _context.Entry (itemToChange).CurrentValues.SetValues (item);
            var result = await _context.SaveChangesAsync ();

            return result > 0;
        }

        public async Task<List<Item>> GetActiveItems () {
            return await _context.Items.Where (x => x.IsActive == true).ToListAsync ();
        }

        public async Task<List<Item>> GetInactiveItems () {
            return await _context.Items.Where (x => x.IsActive == false).ToListAsync ();
        }

        public async Task<List<Item>> GetAllItems () {
            return await _context.Items.Include (x => x.Template).Include(x => x.Order).ToListAsync ();
        }

        public async Task<Item> GetItem (int id) {
            Item item = await _context.Items
                .Where (x => x.Id == id)
                .Include (x => x.Template)
                .Include(x => x.CreatedBy)
                .FirstOrDefaultAsync ();

            _context.Entry(item).Collection (x => x.Parts)
                .Query()
                .Include(x => x.Part)
                .Load();

            item.PartOf = _context.ItemItemRelations.Where(x => x.PartId == item.Id).ToList();
            _context.Entry(item).Collection(x => x.PartOf)
                .Query()
                .Include(x => x.Item)
                .Load ();

            return item;
        }
    }
}