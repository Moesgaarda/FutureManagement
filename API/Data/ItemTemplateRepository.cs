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
            var result = await _context.SaveChangesAsync();

            return result > 0;  // The task result contains the number of objects written to the underlying database.
        }

        public Task<bool> DeleteItemTemplate(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> EditItemTemplate(ItemTemplate template)
        {
            _context.ItemTemplates.Attach(template); //TODO reason to use attach over update https://stackoverflow.com/questions/41025338/why-use-attach-for-update-entity-framework-6 
                                                     // https://stackoverflow.com/questions/30987806/dbset-attachentity-vs-dbcontext-entryentity-state-entitystate-modified
            _context.Entry(template).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            return result > 0;  // The task result contains the number of objects written to the underlying database.
        }

        public async Task<ItemTemplate> GetItemTemplate(int id)
        {
            var result = await _context.ItemTemplates.FirstAsync(x => x.Id == id);
            return result;
        }
    }
}