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
            // await _context.AddAsync(template);
            await _context.ItemTemplates.AddAsync(template);
            var result = _context.SaveChangesAsync();

            return result.IsCompletedSuccessfully;
        }

        public Task<bool> DeleteItemTemplate(ItemTemplate template)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditItemTemplate(ItemTemplate template)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemTemplate> GetItemTemplate(int id)
        {
            var result = await _context.ItemTemplates.FirstAsync(x => x.Id == id);
            return result;
        }
    }
}