using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrder(int orderId){
            throw new NotImplementedException();
        }

        public async Task<Order> CreateOrder(){
            throw new NotImplementedException();
        }

        public async Task<bool> GetAllOrders(){
            throw new NotImplementedException();
        }

        public async void GetPriceHistory(){
            throw new NotImplementedException();
        }

    }
}