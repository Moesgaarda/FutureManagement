using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{

    [Route("api/[controller]")]
    public class OrderController : Controller{
        private readonly DataContext _context;

        public OrderController(DataContext context){
            _context = context;
        }

        public async Task<Order> GetOrder(int orderId){
            return await _context.Orders.FirstAsync(x => x.Id == orderId); 
        }

        public async Task<bool> CreateOrder(Order order){
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllOrders(){
            throw new NotImplementedException();
        }

        public async Task<bool> EditOrder(){
            throw new NotImplementedException(); //TODO Unit testing
        }

        public async Task<bool> UpdateOrderStatus(){
            throw new NotImplementedException(); //TODO Unit testing
        }

    }
}