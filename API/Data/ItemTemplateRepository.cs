using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Enums;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class ItemTemplateRepository : IItemTemplateRepository
    {
        private readonly DataContext _context;
        private readonly IEventLogRepository _eventRepo;

        public ItemTemplateRepository(DataContext context){
            _context = context;
            _eventRepo = new EventLogRepository(_context);
        }

        public async Task<bool> AddItemTemplate(ItemTemplate template)
        {
            await _context.ItemTemplates.AddAsync(template);
            int result = await _context.SaveChangesAsync();

            if(result > 0){
                await _eventRepo.AddEventLogItemTemplate(EventType.Created, template);
            }
            return result > 0;  // The task result contains the number of objects written to the underlying database.
        }

        public async Task<bool> AddPropertyName(ItemPropertyName propertyName)
        {
            await _context.ItemPropertyNames.AddAsync(propertyName);
            int result = await _context.SaveChangesAsync();

            if(result > 0){
                await _eventRepo.AddEventLogItemPropertyName(EventType.Created, propertyName);
            }
            return result > 0;
        }


        /* TODO Maybe check if the Item is in the database
         * This approach is faster though and seems error free (only accesses the database once)
         * Could instead get the item first to check if it exist before removing it (need to access twice)
         * Could maybe use an already local version of the entity instead of the id?
         */
        public async Task<bool> DeleteItemTemplate(ItemTemplate template)
        {
            _context.ItemTemplates.Remove(template); 
            int result = await _context.SaveChangesAsync();     
            return result > 0;
        }

        public async Task<bool> EditItemTemplate(ItemTemplate template)
        {
            var templateToChange = _context.ItemTemplates.First(x => x.Id == template.Id);
            _context.Entry(templateToChange).CurrentValues.SetValues(template);
            var result = await _context.SaveChangesAsync();

            return result > 0;  // The task result contains the number of objects written to the underlying database.
        }

        public async Task<ItemTemplate> GetItemTemplate(int id){
            ItemTemplate template = await _context.ItemTemplates
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

            _context.Entry(template).Collection( x => x.Parts )
                    .Query()
                    .Include(x => x.Part)
                    .Load();

            _context.Entry(template).Collection( x => x.TemplateProperties )
                    .Query()
                    .Include(x => x.Property)
                    .Load();

            template.PartOf = _context.ItemTemplateParts.Where(x => x.PartId == template.Id).ToList();

            _context.Entry(template).Collection(x => x.PartOf)
                    .Query()
                    .Include(x => x.Template)
                    .Load();

            return template;
        }

        public async Task<List<ItemTemplate>> GetItemTemplates()
        {
            return await _context.ItemTemplates.ToListAsync();
        }

        public async Task<ItemPropertyName> GetPropertyName(int id)
        {
            return await _context.ItemPropertyNames.FirstAsync(x => x.Id == id);
        }
        
        public async Task<List<ItemPropertyName>> GetPropertyNames()
        {
            return await _context.ItemPropertyNames.ToListAsync();
        }

        public async Task<bool> ActivateItemTemplate(ItemTemplate template){
            template.IsActive = true;
            _context.ItemTemplates.Update(template);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeactivateItemTemplate(ItemTemplate template){
            template.IsActive = false;
            _context.ItemTemplates.Update(template);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}