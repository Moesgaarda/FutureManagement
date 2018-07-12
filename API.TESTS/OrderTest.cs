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

namespace API.TESTS
{
    public class OrderTest : IDisposable
    {
        private readonly DataContext _dbContext;

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

        private void Seed(DataContext context){
            var orders = new[]{
                new Order { Id = 1, Company = "CompAS", OrderDate = DateTime.Today, DeliveryDate = DateTime.Now, OrderedBy = null, InvoicePath = "core/path.pdf", PurchaseNumber = 1, Width = 123, Height = 312, Length = 213, UnitType = UnitType.cm, Products = null },
                new Order { Id = 2, Company = "Company", OrderDate = DateTime.Today, DeliveryDate = DateTime.Now, OrderedBy = null, InvoicePath = "core/path2.pdf", PurchaseNumber = 2, Width = 1234, Height = 3152, Length = 2123, UnitType = UnitType.mm, Products = null }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        [Fact]
        private async void ReadOrderShouldReturnAResult(){
            // Arrange
            var controller = new OrderController(_dbContext);

            // Act
            var result = await controller.GetOrder(1);

            // Assert
            Assert.True(result.Id == 1);
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}