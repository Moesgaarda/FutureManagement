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

namespace API.TESTS
{
    public class InventoryManagementTest : IDisposable
    {
        private readonly DataContext _dbContext;

        public InventoryManagementTest(){
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
        public async void GetAllActiveItemsTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var activeItems = await controller.GetallActiveItems();
            //Assert
            Assert.Equal(activeItems.Count, 2);
        }

        [Fact]
        public async void GetAllArchivedItems(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var archivedItems = await controller.GetAllArchivedItems();
            //Assert
            Assert.Equal(archivedItems.Count, 1);
        }
        [Fact]
        public async void GetAllItemsTest()
        {
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var allItems = await controller.GetAllItems();
            //Assert
            Assert.Equal(allItems.Count, 3);
        }

        [Fact]
        public async void UpdateItemTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            item.Amount = 5;
            await controller.UpdateItem(item);
            //Assert
            Assert.Equal(_dbContext.Items.FirstOrDefault(x => x.Id == 1).Amount, 5);
            /*Burder jeg teste alle værdier her eller er det her fint nok ? */
        }
        [Fact]
        public async void UpdateItemReturnTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            item.Amount = 5;
            bool status = await controller.UpdateItem(item);
            //Assert
            Assert.True(status);
            /*Burder jeg teste alle værdier her eller er det her fint nok ? */
        }
        [Fact]
        public async void ArchiveItemTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            await controller.ArchiveItem(item);
            //Assert
            Assert.True(_dbContext.Items.FirstOrDefault(x => x.Id == 1).IsArchived);
        }
        [Fact]
        public async void ArchiveItemReturnTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            bool status = await controller.ArchiveItem(item);
            //Assert
            Assert.True(status);
        }
        [Fact]
        public async void DeletItemTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            await controller.DeleteItem(item);
            //Assert
            Assert.Null(_dbContext.Items.First(x => x.Id == 1));
        }
        [Fact]
        public async void DeletItemReturnTest(){
            //Arrange
            var controller = new InventoryManagementController(_dbContext);
            //Act
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            var status = await controller.DeleteItem(item);
            //Assert
            Assert.True(status);
        }
        private void Seed(DataContext context){
            var itemProperties = new[]{
                new ItemProperty("gul"),
                new ItemProperty("halv"), 
                new ItemProperty("slebet")
            };
            context.ItemProperties.AddRange(itemProperties);
            context.SaveChanges();
            var itemPropertyCategories = new[]{
                new ItemPropertyCategory("Farve"),
                new ItemPropertyCategory("Behandling"),
                new ItemPropertyCategory("skæring")
            };
            context.ItemPropertyCategories.AddRange(itemPropertyCategories);
            context.SaveChanges();

            var itemTemplates = new[]{
                new ItemTemplate(
                    "Gavl", 
                    UnitType.m, 
                    "Dette er en gavl", 
                    new List<ItemPropertyCategory>(){context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2)}, 
                    new List<ItemTemplate>(){}
                ),
                new ItemTemplate(
                    "stang", 
                    UnitType.m, 
                    "Dette er en stang", 
                    new List<ItemPropertyCategory>(){context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2)}, 
                    new List<ItemTemplate>(){}
                ),
                new ItemTemplate(
                    "tagplade", 
                    UnitType.m, 
                    "Dette er en tagplade", 
                    new List<ItemPropertyCategory>(){context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2)}, 
                    new List<ItemTemplate>(){}
                )
            };
            context.ItemTemplates.AddRange(itemTemplates);
            context.SaveChanges();
            var users = new[]{
                new User(
                    "bjarne52",
                    new UserRole("Produktion"),
                    "Bjarne",
                    "Hansen",
                    new DateTime(1980, 1, 18),
                    true,
                    "Bjarne@FutureRundbuehaller.dk",
                    29292929
                )
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            var orders = new[]{
                new Order("CompanyA", 
                    DateTime.Today, 
                    DateTime.Now, 
                    context.Users.FirstOrDefault(x => x.Id == 1), 
                    "core/pathA.pdf", 
                    1, 
                    123, 
                    456, 
                    789, 
                    UnitType.cm,
                    new List<Item>()),
                new Order("CompanyB", 
                    DateTime.Today, 
                    DateTime.Now, 
                    context.Users.FirstOrDefault(x => x.Id == 1), 
                    "core/pathB.pdf", 
                    2, 
                    345, 
                    678, 
                    910, 
                    UnitType.mm,
                    new List<Item>()),
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();
            
            var items = new[]{
                new Item(
                    "42d",
                    12,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 1),
                    context.Orders.FirstOrDefault(x => x.Id == 1),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemProperty>(){context.ItemProperties.FirstOrDefault(X => X.Id == 1)},
                    new List<Item>(),
                    false
                ),
                new Item(
                    "41d",
                    11,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 2),
                    context.Orders.FirstOrDefault(x => x.Id == 1),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemProperty>(){context.ItemProperties.FirstOrDefault(X => X.Id == 2)},
                    new List<Item>(),
                    false
                ),
                new Item(
                    "40d",
                    12,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 3),
                    context.Orders.FirstOrDefault(x => x.Id == 2),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemProperty>(){context.ItemProperties.FirstOrDefault(X => X.Id == 1)},
                    new List<Item>(),
                    true
                )
            };
            context.Items.AddRange(items);
            context.SaveChanges();
            var order = context.Orders.FirstOrDefault(x => x.Id == 1);
            order.Products.Add(context.Items.FirstOrDefault(x => x.Id == 1));
            order.Products.Add(context.Items.FirstOrDefault(x => x.Id == 2));
            context.Orders.Update(order);
            context.SaveChanges();
            order = context.Orders.FirstOrDefault(x => x.Id == 2);
            order.Products.Add(context.Items.FirstOrDefault(x => x.Id == 3));
            context.Orders.Update(order);
            context.SaveChanges();

        }
        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}