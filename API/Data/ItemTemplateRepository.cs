using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ItemTemplateRepository : IItemTemplateRepository
    {
        private readonly DataContext _context;

        public ItemTemplateRepository(DataContext context){
            _context = context;
        }

        public async Task<bool> AddItemTemplate(ItemTemplate template)
        {
            await _context.ItemTemplates.AddAsync(template);
            int result = await _context.SaveChangesAsync();

            return result > 0;  // The task result contains the number of objects written to the underlying database.
        }

        public async Task<bool> AddPropertyTemplate(ItemProperty propertyTemplate)
        {
            await _context.ItemProperties.AddAsync(propertyTemplate);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }


        /* TODO Maybe check if the Item is in the database
         * This approach is faster though and seems error free (only accesses the database once)
         * Could instead get the item first to check if it exist before removing it (need to access twice)
         * Could maybe use an already local version of the entity instead of the id?
         */
        public async Task<bool> DeleteItemTemplate(int id)
        {
            ItemTemplate template = new ItemTemplate() {Id = id};
            _context.ItemTemplates.Attach(template); 
            _context.ItemTemplates.Remove(template); 
            int result = _context.SaveChanges();     
            return result > 0;
        }

        public async Task<bool> EditItemTemplate(ItemTemplate template)
        {
            //_context.ItemTemplates.Attach(template); 
                                                    //TODO reason to use attach over update https://stackoverflow.com/questions/41025338/why-use-attach-for-update-entity-framework-6 
                                                    // https://stackoverflow.com/questions/30987806/dbset-attachentity-vs-dbcontext-entryentity-state-entitystate-modified
            _context.ItemTemplates.Update(template);
            var result = await _context.SaveChangesAsync();

            return result > 0;  // The task result contains the number of objects written to the underlying database.
        }

        public async Task<ItemTemplate> GetItemTemplate(int id)
        {
            var result = await _context.ItemTemplates.FirstAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<ItemTemplate>> GetItemTemplates()
        {
            var results = await _context.ItemTemplates.Where(x => x.Id > 0).ToListAsync();
            return results;
            //return result;
        }
    }
}