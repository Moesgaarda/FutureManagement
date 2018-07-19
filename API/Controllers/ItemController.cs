using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext _context;
        public ItemController(DataContext context){
            _context = context;
        }
        public async Task<List<Item>> GetallActiveItems(){
            throw new NotImplementedException();
        }
        public async Task<List<Item>> GetAllArchivedItems(){
            throw new NotImplementedException();
        }
        public async Task<List<Item>> GetAllItems(){
            throw new NotImplementedException();
        }
        public async Task<Item> GetItem(int id){
            throw new NotImplementedException();
        }
        public async Task<Item> ShowDetails(Item item){
            throw new NotImplementedException();
        }
        public async Task<bool> CreateItem(Item item){
            throw new NotImplementedException();
        }
        public async Task<bool> EditItem(Item item){
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteItem(Item item){
            throw new NotImplementedException();
        }
        public async Task<bool> ArchiveItem(Item item){
            throw new NotImplementedException();
        }
    }
}