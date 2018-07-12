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

namespace API.TESTS{
    public class CustomerTest : IDisposable{
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
                new Customer(
                    "Viborg", 
                    "DK", 
                    "john@bob.dk", 
                    "John Bob",
                    "+4512457845", 
                    "+4523451659", 
                    "none", 
                    new CustomerType("Privat")
                ),

                new Customer(
                    "Gedsted", 
                    "DK", 
                    "bob@john.dk", 
                    "Bob John", 
                    "+4511223344", 
                    "+4555668844", 
                    "Futty", 
                    new CustomerType("Erhverv")
                ),
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

        [Fact]
        private async void AddNewCustomerReturnsTrue(){
            // Arrange
            var controller = new CustomerController(_dbContext);
            var testCustomer = new Customer(
                    "Nyborg", 
                    "DK", 
                    "john@bobby.dk", 
                    "John Bobsen",
                    "+4512457345", 
                    "+4523451659", 
                    "none", 
                    new CustomerType("Privat")
                );

            // Act
            var result = await controller.AddNewCustomer(testCustomer);

            // Assert 
            Assert.True(result);

        }

        [Fact]
        private async void AddNewCustomerAddsUser(){
            // Arrange
            var controller = new CustomerController(_dbContext);
            var testCustomer = new Customer(
                    "Aalborg", 
                    "DK", 
                    "eva@drivehouse.dk", 
                    "Eva Evansen",
                    "+4512457845", 
                    "+4523451659", 
                    "Drive House", 
                    new CustomerType("Erhverv")
                );

            // Act
            await controller.AddNewCustomer(testCustomer);
            var result = controller.GetCustomer(3);

            // Assert 
            Assert.Equal(result.Result, testCustomer);
        }

        [Fact]
        private async void DeleteCustomerReturnsTrueIfSuccess(){
            // Arrange
            var controller = new CustomerController(_dbContext);

            // Act
            var result = await controller.DeleteCustomer(2);

            // Assert
            Assert.Equal(result, true);
        }

        [Fact]
        private async void DeleteCustomerReturnsFalseIfUnsuccess(){
            // Arrange
            var controller = new CustomerController(_dbContext);

            // Act
            var result = await controller.DeleteCustomer(5);

            // Assert
            Assert.Equal(result, false);
        }

        [Fact]
        private async void ChangeCustomerInformationSuccess(){
            // Arrange
            var controller = new CustomerController(_dbContext);
            var testCustomer = new Customer(
                1,
                "Aalborg", 
                "DK", 
                "eva@drivehouse.dk", 
                "Eva Evansen",
                "+4512457845", 
                "+4523451659", 
                "Drive House", 
                new CustomerType("Erhverv")
            );

            // Act
            var result = await controller.UpdateCustomer(testCustomer);

            // Assert
            Assert.Equal(result, true);
        }

        [Fact]
        private async void ChangeCustomerInformationUnsuccess(){
            // Arrange
            var controller = new CustomerController(_dbContext);
            var testCustomer = new Customer(
                1,
                "", 
                "", 
                "", 
                "",
                "", 
                "", 
                "", 
                new CustomerType("")
            );

            // Act
            var result = await controller.UpdateCustomer(testCustomer);

            // Assert
            Assert.Equal(result, false);
        }

        [Fact]
        private async void GetCustomer(){
            // Arrange
            var controller = new CustomerController(_dbContext);

            // Act
            var result = await controller.GetCustomer(1);

            // Assert
            Assert.Equal(result.Id, 1);
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}