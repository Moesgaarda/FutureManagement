using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ItemSystemController : Controller
    {
        private readonly DataContext _context;
        public ItemSystemController(DataContext context){
            _context = context;
        }
        public async Task<Item> ShowDetailsItem(int id){
            throw new NotImplementedException();
        }
        public async Task<ItemTemplate> ShowDetailsTemplate(int id){
            throw new NotImplementedException();
        }
        public async Task<bool> CreateTemplate(ItemTemplate template){
            throw new NotImplementedException();
        }
        public async Task<bool> EditTemplate(ItemTemplate template){
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteTemplate(ItemTemplate template){
            throw new NotImplementedException();
        }
    }
}