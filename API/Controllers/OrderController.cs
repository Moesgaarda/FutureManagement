using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{

    [Route("api/[controller]")]
    public class OrderController : Controller{
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;

        public OrderController(DataContext context, IMapper mapper, IOrderRepository repo){
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Order> GetOrder(int orderId){
            return await _context.Orders.FirstAsync(x => x.Id == orderId); 
        }

        public Task<bool> CreateOrder(Order order){
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrders(){
            throw new NotImplementedException();
        }

        public Task<bool> EditOrder(){
            throw new NotImplementedException(); //TODO Unit testing
        }

        public Task<bool> UpdateOrderStatus(){
            throw new NotImplementedException(); //TODO Unit testing
        }

    }
}