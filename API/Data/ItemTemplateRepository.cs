using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Dtos.FileDtos;
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

        public ItemTemplateRepository(DataContext context){
            _context = context;
        }

        public async Task<bool> AddItemTemplate(ItemTemplate template)
        {
            foreach(var part in template.Parts){
                part.Part = await _context.ItemTemplates.FirstOrDefaultAsync(x => x.Id == part.Part.Id);
            }

            foreach(var prop in template.TemplateProperties){
                prop.Property = await _context.ItemPropertyNames.FirstOrDefaultAsync(x => x.Id == prop.PropertyId);
            }
            foreach(var file in template.Files){
                file.FileData = await _context.FileData.FirstOrDefaultAsync(x => x.Id == file.FileData.Id);
            }

            if(template.RevisionedFrom != null){
                template.RevisionedFrom = await _context.ItemTemplates.FirstOrDefaultAsync(x => x.Id == template.RevisionedFrom.Id);
            }

            if(template.UnitType != null){
                template.UnitType = await _context.UnitTypes.FirstOrDefaultAsync(x => x.Id == template.UnitType.Id);
            }

            if(template.Category != null){
                template.Category = await _context.ItemTemplateCategories.FirstOrDefaultAsync(x => x.Id == template.Category.Id);
            }

            await _context.ItemTemplates.AddAsync(template);
            int result = await _context.SaveChangesAsync();

            return result > 0;  // The task result contains the number of objects written to the underlying database.
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
                    .Include(x => x.RevisionedFrom)
                    .Include(x => x.Category)
                    .Include(x => x.UnitType)
                    .Include(x => x.Parts)
                    .ThenInclude(x => x.Part)
                    .Include(x => x.TemplateProperties)
                    .ThenInclude(x => x.Property)
                    .Include(x => x.PartOf)
                    .ThenInclude(x => x.Template)
                    .Include(x => x.Files)                
                    .ThenInclude(x => x.FileData)
                    .FirstOrDefaultAsync(x => x.Id == id);            
                    
            return template;
        }

        public async Task<List<ItemTemplate>> GetItemTemplates()
        {
            return await _context.ItemTemplates.Include(x => x.Category).ToListAsync();
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
         public async Task<List<TemplateFileName>> GetFiles(int id){
            List<TemplateFileName> files = await _context.TemplateFileNames.Where(x => x.ItemTemplate.Id == id).ToListAsync();
            return files;
        }
    }
}