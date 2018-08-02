using System;
using Xunit;
using API;
using API.Models;
using API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using API.Enums;
using API.Data;
using System.Collections.Generic;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.TESTS
{
    public class OrderTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper; 
        private readonly IOrderRepository _repo;

        public OrderTest(){
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _dbContext = new DataContext(options);
            _dbContext.Database.EnsureCreated();
            Seed(_dbContext);

            _repo = new OrderRepository(_dbContext);
            MapperConfiguration config = new MapperConfiguration( cfg => {
                cfg.CreateMap<Order, OrderForGetDto>();
            });
            
            _mapper =  config.CreateMapper();
        }


        [Fact]
        private async void GetOrderTest(){
            // Arrange
            var controller = new OrderController(_dbContext, _mapper, _repo);

            // Act
            IActionResult result = await controller.GetOrder(1);
            OkObjectResult intermediate = result as OkObjectResult;
            Order order = intermediate.Value as Order;
            
            // Assert
            Assert.True(order.Id == 1);
            
        }

        [Fact]
        private async void GetOrderReturnsFalseResultTest(){
            // Arrange
            var controller = new OrderController(_dbContext, _mapper, _repo);

            // Act
            IActionResult result = await controller.GetOrder(2);
            OkObjectResult intermediate = result as OkObjectResult;
            Order order = intermediate.Value as Order;

            // Assert
            Assert.False(order.Id == 1);
        }

        [Fact]
        private async void InsertOrderUnsuccessfullyTest(){
            // Arange
            var controller = new OrderController(_dbContext, _mapper, _repo);
            var testOrder = new Order();

            // Act
            var status = await controller.AddOrder(testOrder);

            // Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(201);
            Assert.False(result.StatusCode == test.StatusCode);
        }

        [Fact]
        private async void InsertOrderSuccessfullyTest(){
            // Arange
            var controller = new OrderController(_dbContext, _mapper, _repo);
            var testOrder = new Order(
                    "CompanyC", 
                    DateTime.Today, 
                    DateTime.Now, 
                    null, 
                    "core/pathA.pdf", 
                    1, 
                    486, 
                    153, 
                    125, 
                    UnitType.cm,
                    null
                );

            // Act
            var status = await controller.AddOrder(testOrder);

            // Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(201);
            Assert.True(result.StatusCode == test.StatusCode);
        }

        [Fact]
        private async void GetAllOrdersGetsAllOrdersTest(){
            // Arrange
            var controller = new OrderController(_dbContext, _mapper, _repo);

            // Act
            IActionResult allOrders = await controller.GetAllOrders();
            OkObjectResult intermediate = allOrders as OkObjectResult;
            List<Order> result = allOrders as List<Order>;

            // Assert
            Assert.True(result.Count == 2);
        }

        private void Seed(DataContext context){
            var orders = new[]{
                new Order("CompanyA", 
                    DateTime.Today, 
                    DateTime.Now, 
                    null, 
                    "core/pathA.pdf", 
                    1, 
                    123, 
                    456, 
                    789, 
                    UnitType.cm,
                    null),
                new Order("CompanyB", 
                    DateTime.Today, 
                    DateTime.Now, 
                    null, 
                    "core/pathB.pdf", 
                    2, 
                    345, 
                    678, 
                    910, 
                    UnitType.mm,
                    null),
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}