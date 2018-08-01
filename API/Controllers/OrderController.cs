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

        [HttpGet("get/{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int orderId){
            var order = await _repo.GetOrder(orderId);
            
            return Ok(order);
        }

        [HttpPost("add", Name = "AddItemToOrder")]
        public async Task<IActionResult> AddOrder(Order order){
            var orderToCreate = new Order(
                order.Company,
                order.OrderDate,
                order.DeliveryDate,
                order.OrderedBy,
                order.InvoicePath,
                order.PurchaseNumber,
                order.Width,
                order.Height,
                order.Length,
                order.UnitType,
                order.Products
            );

            bool result = await _repo.AddOrder(orderToCreate);
            return result ? StatusCode(201) : BadRequest();
        }
        

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllOrders(){
            var orders = await _repo.GetAllOrders();

            return Ok(orders);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditOrder([FromBody]Order order){
            if(order.Id == 0){
                ModelState.AddModelError("Order Error","Order id can not be 0.");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            bool result = await _repo.EditOrder(order);

            return result ? StatusCode(200) : StatusCode(400);
        }

        
        [HttpPost("delete/{id}", Name = "DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id){
            if(id == 0){
                ModelState.AddModelError("Order Error","Can not delete order with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var order = await _repo.GetOrder(id);

            bool result = await _repo.DeleteOrder(order);

            return result ? StatusCode(200) : BadRequest();
        }

        public Task<bool> UpdateOrderStatus(){
            throw new NotImplementedException(); //TODO Unit testing
        }

    }
}