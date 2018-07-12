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
    public class CustomerTest : IDisposable
    {
        private readonly DataContext _dbContext;

        public CustomerTest(){
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
            var customers = new[]{
                new Customer("Viborg", "DK", "john@bob.dk", "John Bob", "+4512457845", "+4523451659", "none", new CustomerType("Privat")),
                new Customer("Gedsted", "DK", "bob@john.dk", "Bob John", "+4512457845", "+4559486573", "Futty", new CustomerType("Privat")),
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        [Fact]
        private async void GetAllCustomersGetsAllCustomers(){
            // Arrange
            var controller = new CustomerController(_dbContext);

            // Act
            var result = await controller.GetAllCustomers();

            // Assert
            Assert.Equal(result.Count, 2);
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}