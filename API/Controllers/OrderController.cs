using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.OrderDtos;
using API.Enums;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{

    [Route("api/[controller]")]
    public class OrderController : Controller{
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly IEventLogRepository _eventLogRepo;

        public OrderController(DataContext context, IMapper mapper, IOrderRepository repo, 
                                UserManager<User> userManager, IEventLogRepository eventLogRepo){
            _context = context;
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _eventLogRepo = eventLogRepo;
        }

        [Authorize(Policy = "Order_View")]
        [HttpGet("get/{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id){
            var order = await _repo.GetOrder(id);
            return Ok(order);
        }

        [Authorize(Policy = "Order_Add")]
        [HttpPost("add", Name = "AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody]OrderForAddDto OrderDto){       
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            List<OrderFileName> filesToAdd = new List<OrderFileName>();
            if(OrderDto.Files != null){
                for(int i = 0; i < OrderDto.Files.Length; i++){
                    filesToAdd.Add(new OrderFileName{
                        FileData = new FileData{
                            Id = OrderDto.Files[i]
                        },
                        FileName = OrderDto.FileNames[i]
                    });
                }
            }


            Order orderToCreate = new Order(
                OrderDto.Company,
                OrderDto.OrderDate,
                OrderDto.DeliveryDate,
                OrderDto.OrderedBy,
                OrderDto.PurchaseNumber,
                OrderDto.Width,
                OrderDto.Height,
                OrderDto.Length,
                // TODO ændre det sådan at vi bruger Unit Type som en model i SPa'en
                new UnitType(){
                    Name = OrderDto.UnitType
                },
                OrderDto.Products,
                filesToAdd, 
                OrderDto.Status
            );

            bool result = await _repo.AddOrder(orderToCreate);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "bestilling", "Købsnummer: " + orderToCreate.PurchaseNumber.ToString(), orderToCreate.Id, currentUser);
            }
            return result ? StatusCode(201) : BadRequest();          
        }
        
        [Authorize(Policy = "Order_View")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllOrders(){
            var orders = await _repo.GetAllOrders();

            return Ok(orders);
        }

        [Authorize(Policy = "Order_View")]
        [HttpGet("getIncoming")]
        public async Task<IActionResult> GetIncoming(){
            var orders = await _repo.GetAllOrders();
            orders = orders.Where(x => x.DeliveryDate > DateTime.Now && x.DeliveryDate < DateTime.Now.AddMonths(2)).ToList();
            return Ok(orders);
        }

        [Authorize(Policy = "Order_View")]
        [HttpGet("getNotDelivered")]
        public async Task<IActionResult> GetNotDelivered(){
            var orders = await _repo.GetAllOrders();
            orders = orders.Where(x => x.Status == OrderStatusEnum.Bestilt).ToList();
            return Ok(orders);
        }

        [Authorize(Policy = "Order_Edit")]
        [HttpPost("edit")]
        public async Task<IActionResult> EditOrder([FromBody]Order order){
            if(order.Id == 0){
                ModelState.AddModelError("Order Error","Order id can not be 0.");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var orderToChange = await _context.Orders.FirstAsync(x => x.Id == order.Id);
            bool result = await _repo.EditOrder(order, orderToChange);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLogChange("bestilling", "Købsnummer: " + order.PurchaseNumber.ToString(), order.Id, currentUser, order, orderToChange);
            }

            return result ? StatusCode(200) : StatusCode(400);
        }

        [Authorize(Policy = "Order_Delete")]
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

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Deleted, "bestilling", "Købsnummer: " + order.PurchaseNumber.ToString(), order.Id, currentUser);
            }

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "Order_Edit")]
        public Task<bool> UpdateOrderStatus(){
            throw new NotImplementedException(); //TODO Unit testing
        }

    }
}