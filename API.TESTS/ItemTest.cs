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
    
    public class ItemTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper; 
        private readonly IItemRepository _repo;

        public ItemTest(){
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

            _repo = new ItemRepository(_dbContext);
            MapperConfiguration config = new MapperConfiguration( cfg => {
                cfg.CreateMap<ItemTemplate, ItemTemplateForGetDto>();
                cfg.CreateMap<ItemTemplate, ItemTemplateForAddDto>();
                cfg.CreateMap<ItemTemplate, ItemTemplateForTableDto>();

            });
            
            _mapper =  config.CreateMapper();
        }

        [Fact]
        public async void GetAllActiveItemsTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            // Act
            IActionResult allActiveItems = await itemController.GetallActiveItems();
            OkObjectResult intermediate = allActiveItems as OkObjectResult;
            List<Item> result = intermediate.Value as List<Item>;
            // Assert
            Assert.True(result.Count == 2);
        }

        [Fact]
        public async void GetAllInactiveItemsTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            // Act
            IActionResult allActiveItems = await itemController.GetAllInactiveItems();
            OkObjectResult intermediate = allActiveItems as OkObjectResult;
            List<Item> result = intermediate.Value as List<Item>;
            // Assert
            Assert.True(result.Count == 1);
        }

        [Fact]
        public async void GetAllItemsTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            // Act
            IActionResult allActiveItems = await itemController.GetAllItems();
            OkObjectResult intermediate = allActiveItems as OkObjectResult;
            List<Item> result = intermediate.Value as List<Item>;
            // Assert
            Assert.True(result.Count == 3);
        }

        [Fact]
        public async void EditItemTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            // Act
            item.Placement = "Denne placering er ændret";
            await itemController.EditItem(item);
            var editedItem = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            // Assert
            Assert.True(editedItem.Placement == item.Placement);
        }

        [Fact]
        public async void EditItemReturnTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);            
            // Act
            item.Placement = "En ny placering";
            var status = await itemController.EditItem(item);
            //Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(200);
            Assert.True(result.StatusCode == test.StatusCode);
        }

        [Fact]
        public async void DeactivateItemTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);            
            // Act
            await itemController.DeactivateItem(item);
            Item editedItem = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            //Assert
            Assert.True(editedItem.IsActive == true);
            
        }

        [Fact]
        public async void ArchiveItemReturnTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);            
            // Act
            var status = await itemController.DeactivateItem(item);
            // Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(200);
            Assert.True(result.StatusCode == test.StatusCode);
        }

        [Fact]
        public async void DeleteItemTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper); 
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1); 

            // Act
            await itemController.DeleteItem(item);

            // Assert
            var result = _dbContext.Items.FirstOrDefault(x => x.Id == 1);
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteItemReturnTest(){
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == 1);            
            // Act
            var status = await itemController.DeleteItem(item);
            // Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(200);
            Assert.True(result.StatusCode == test.StatusCode);
        }
        
        [Fact]
        public async void CreateItemTest()
        {
            // Arrange
            var itemController = new ItemController(_repo, _dbContext, _mapper);
            Item itemToCreate = new Item(
                "D4",
                23,
                _dbContext.ItemTemplates.FirstOrDefault(x => x.Id==1),
                _dbContext.Orders.FirstOrDefault(x => x.Id == 1),
                _dbContext.Users.FirstOrDefault(x => x.Id == 1),
                new List<ItemPropertyDescription> {_dbContext.ItemPropertyDescriptions.FirstOrDefault(x => x.Id == 1)},
                new List<Item> {_dbContext.Items.FirstOrDefault(x => x.Id == 1)},
                true
            );
            
            // Act
            var itemDTO = _mapper.Map<ItemForAddDto>(itemToCreate);
            await itemController.AddItem(itemDTO);
            var item = _dbContext.Items.FirstOrDefault(x => x.Placement == "D4");

            // Assert
            Assert.True(item.Amount == 23);
        }

        [Fact]
        public async void CreateItemReturnTest(){
            // Arrange
            var controller = new ItemController(_repo, _dbContext, _mapper);
            Item createdItem = new Item(
                "D4",
                10,
                _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1),
                _dbContext.Orders.FirstOrDefault(x => x.Id == 1),
                _dbContext.Users.FirstOrDefault(x => x.Id == 1),
                new List<ItemPropertyDescription> {_dbContext.ItemPropertyDescriptions.FirstOrDefault(x=> x.Id == 1)},
                new List<Item> {_dbContext.Items.FirstOrDefault(x => x.Id == 1)},
                false
                );
            
            // Act
            var itemDTO = _mapper.Map<ItemForAddDto>(createdItem);
            var status = await controller.AddItem(itemDTO);
            // Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(201);
            Assert.True(result.StatusCode == test.StatusCode);


        }
        
        private void Seed(DataContext context){
            
            var itemProperties = new[]{
                new ItemPropertyDescription(1, "gul"),
                new ItemPropertyDescription(2, "halv"), 
                new ItemPropertyDescription(3, "slebet")
            };
            context.ItemPropertyDescriptions.AddRange(itemProperties);
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