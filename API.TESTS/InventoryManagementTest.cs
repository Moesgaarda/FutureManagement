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

        }

        [Fact]
        public async void GetAllArchivedItemsTest(){

        }

        [Fact]
        public async void GetAllItemsTest(){

        }

        [Fact]
        public async void EditItemTest(){

        }

        [Fact]
        public async void EditItemReturnTest(){

        }

        [Fact]
        public async void ArchiveItemTest(){

        }

        [Fact]
        public async void ArchiveItemReturnTest(){

        }

        [Fact]
        public async void DeletItemTest(){

        }

        [Fact]
        public async void DeletItemReturnTest(){

        }
        
        [Fact]
        public async void CreateItemTest()
        {

        }

        [Fact]
        public async void CreatItemReturnTest()
        {

        }
        
        private void Seed(DataContext context){
            
            var itemProperties = new[]{
                new ItemPropertyDescription(1, "gul"),
                new ItemPropertyDescription(2, "halv"), 
                new ItemPropertyDescription(3, "slebet")
            };
            context.ItemPropertyDescriptions.AddRange(itemProperties);
            context.SaveChanges();
            var itemPropertyCategories = new[]{
                new ItemPropertyName("Farve"),
                new ItemPropertyName("Behandling"),
                new ItemPropertyName("skæring")
            };
            context.ItemPropertyNames.AddRange(itemPropertyCategories);
            context.SaveChanges();

            var itemTemplates = new[]{
                new ItemTemplate(
                    "Gavl", 
                    UnitType.m, 
                    "Dette er en gavl", 
                    new List<TemplateProperty>(){context.TemplateProperties.FirstOrDefault(x => x.TemplateId == 1), context.TemplateProperties.FirstOrDefault(x => x.TemplateId == 2)}, 
                    new List<ItemTemplatePart>(){},
                    "Gavl.pdf"
                ),
                new ItemTemplate(
                    "Stang", 
                    UnitType.m, 
                    "Dette er en stang", 
                    new List<TemplateProperty>(){context.TemplateProperties.FirstOrDefault(x => x.TemplateId == 1), context.TemplateProperties.FirstOrDefault(x => x.TemplateId == 2)}, 
                    new List<ItemTemplatePart>(){},
                    "Stang.pdf"
                ),
                new ItemTemplate(
                    "Tagplade", 
                    UnitType.m, 
                    "Dette er en tagplade", 
                    new List<TemplateProperty>(){context.TemplateProperties.FirstOrDefault(x => x.TemplateId == 1), context.TemplateProperties.FirstOrDefault(x => x.TemplateId == 2)}, 
                    new List<ItemTemplatePart>(){},
                    "Tagplade.pdf"
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
                    new List<ItemPropertyDescription>(){context.ItemPropertyDescriptions.FirstOrDefault(X => X.Id == 1)},
                    new List<Item>(),
                    false
                ),
                new Item(
                    "41d",
                    11,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 2),
                    context.Orders.FirstOrDefault(x => x.Id == 1),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemPropertyDescription>(){context.ItemPropertyDescriptions.FirstOrDefault(X => X.Id == 2)},
                    new List<Item>(),
                    false
                ),
                new Item(
                    "40d",
                    12,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 3),
                    context.Orders.FirstOrDefault(x => x.Id == 2),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemPropertyDescription>(){context.ItemPropertyDescriptions.FirstOrDefault(X => X.Id == 1)},
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