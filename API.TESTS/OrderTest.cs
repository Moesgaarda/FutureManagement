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
using AutoMapper;
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
        }


        [Fact]
        private async void ReadOrderReturnsCorrectResultTest(){
            // Arrange
            var controller = new OrderController(_dbContext, _mapper, _repo);

            // Act
            var result = await controller.GetOrder(1);

            // Assert
            Assert.True(result.Id == 1);
        }

        [Fact]
        private async void ReadOrderReturnsFalseResultTest(){
            // Arrange
            var controller = new OrderController(_dbContext, _mapper, _repo);

            // Act
            var result = await controller.GetOrder(2);

            // Assert
            Assert.False(result.Id == 1);
        }

        [Fact]
        private async void InsertOrderUnsuccessfullyTest(){
            // Arange
            var controller = new OrderController(_dbContext, _mapper, _repo);
            var testOrder = new Order();

            // Act
            var result = await controller.CreateOrder(testOrder);

            // Assert
            Assert.False(result);
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
            var result = await controller.CreateOrder(testOrder);

            // Assert
            Assert.True(result);
        }

        [Fact]
        private async void GetAllOrdersGetsAllOrdersTest(){
            // Arrange
            var controller = new OrderController(_dbContext, _mapper, _repo);

            // Act
            IActionResult result = await controller.GetAllOrders();

            // Assert
            Assert.Equal(2, result.Count);
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