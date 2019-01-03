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

namespace API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly ItemRepository _itemRepo;
        public OrderRepository(DataContext context){
            _context = context;
            _itemRepo = new ItemRepository(context);
        }
        public async Task<bool> AddOrder(Order order)
        {
            if(order.OrderedBy != null){
                order.OrderedBy = await _context.Users.FirstOrDefaultAsync(x => x.Id == order.OrderedBy.Id);
            }else{
                order.OrderedBy = await _context.Users.FirstOrDefaultAsync(x => x.Id == 1);
            }
            order.Status = await _context.OrderStatuses.FirstOrDefaultAsync(x => x.Id == order.Status.Id);
            
            foreach(Item product in order.Products){
                product.Template = await _context.ItemTemplates.FirstOrDefaultAsync(x => x.Id == product.Template.Id);
                foreach(ItemPropertyDescription property in product.Properties){
                    property.PropertyName = await _context.ItemPropertyNames.FirstOrDefaultAsync(x => x.Id == property.PropertyName.Id);
                }
                
            }
            order.UnitType = await _context.UnitTypes.FirstOrDefaultAsync( x => x.Name == order.UnitType.Name);
            
            foreach(var file in order.Files){
                file.FileData = await _context.FileData.FirstOrDefaultAsync(x => x.Id == file.FileData.Id);
            }

            await _context.Orders.AddAsync(order);
            
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EditOrder(Order order, Order orderToChange)
        {
            _context.Entry(orderToChange).CurrentValues.SetValues(order);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(x => x.Status)
                .ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<OrderStatus>> GetAllStatuses(){
            return await _context.OrderStatuses.ToListAsync();
        }
    }
}