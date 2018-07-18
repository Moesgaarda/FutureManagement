using System;
using Xunit;
using API.Models;
using API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using API.Enums;
using API.Data;
using System.Collections.Generic;
using API.Helpers;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.TESTS
{
    public class ItemSystemTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper; 
        private readonly IItemTemplateRepository _repo;
        public ItemSystemTest()
        {
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

            _repo = new ItemTemplateRepository(_dbContext);
            MapperConfiguration config = new MapperConfiguration( cfg => {
                cfg.CreateMap<ItemTemplate, ItemTemplateForGetDto>();
                cfg.CreateMap<ItemTemplate, ItemTemplateForAddDto>();
                cfg.CreateMap<ItemTemplate, ItemTemplateForTableDto>();

            });
            
            _mapper =  config.CreateMapper();
        }

        [Fact]
        public async void ShowDetailsTemplateTest()
        {
            //Given
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            //When
            
            IActionResult template = await controller.GetItemTemplate(1);
            //Then
            ItemTemplate temp = template as ItemTemplate;

            Assert.Equal(temp.Id , 1);
        }
        /* 
        [Fact]
        public async void CreateTemplateTest()
        {
            //Given
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            var template = new ItemTemplate(
                "Dør",
                UnitType.m,
                "Dette er en Dør",
                new List<ItemPropertyCategory>() { _dbContext.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), _dbContext.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2) },
                new List<ItemTemplate>() { },
                "file/string/path"
            );
            //When
            await controller.AddItemTemplate(template);
            var dbTemplate = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 4);
            //Then
            Assert.True(dbTemplate.Id == 4 && dbTemplate.Name == template.Name);
        }
        public async void CreateTemplateReturnTest()
        {
            //Given
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            var template = new ItemTemplate(
                "Dør",
                UnitType.m,
                "Dette er en Dør",
                new List<ItemPropertyCategory>() { _dbContext.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), _dbContext.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2) },
                new List<ItemTemplate>() { },
                "file/string/path"
            );
            //When
            var status = await controller.AddItemTemplate(template);
            //Then
            Assert.True(status);
        }
        [Fact]
        public async void EditTemplateTest()
        {
            //Arrange
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            template.Description = "En Ny beskrivelse";
            template.Properties.Add(_dbContext.ItemPropertyCategories.FirstOrDefault(x => x.Id == 3));
            await controller.EditItemTemplate(template);
            var editedTemplate = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Assert
            Assert.True(editedTemplate.Description == template.Description && editedTemplate.Properties.Count == 3);
        }
        [Fact]
        public async void EditTemplateReturnTest()
        {
            //Arrange
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            template.Description = "En Ny beskrivelse";
            template.Properties.Add(_dbContext.ItemPropertyCategories.FirstOrDefault(x => x.Id == 3));
            var status = await controller.EditItemTemplate(template);
            //Assert
            Assert.True(status);
        }
        [Fact]
        public async void DeleteTemplateTest()
        {
            //Arrange
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            await controller.DeleteItemTemplate(template.id);
            //Assert
            Assert.Null(_dbContext.ItemTemplates.First(x => x.Id == 1));
        }
        [Fact]
        public async void DeleteTemplateTestReturn()
        {
            //Arrange
            var controller = new ItemSystemController(_repo,_dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            var status = await controller.DeleteItemTemplate(template.Id);
            //Assert
            Assert.True(status);
        }
        */
        private void Seed(DataContext context)
        {
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
                    new List<ItemTemplate>(){},
                    "file/string/path"
                ),
                new ItemTemplate(
                    "stang",
                    UnitType.m,
                    "Dette er en stang",
                    new List<ItemPropertyCategory>(){context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2)},
                    new List<ItemTemplate>(){},
                    "file/string/path"
                ),
                new ItemTemplate(
                    "tagplade",
                    UnitType.m,
                    "Dette er en tagplade",
                    new List<ItemPropertyCategory>(){context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 1), context.ItemPropertyCategories.FirstOrDefault(x => x.Id == 2)},
                    new List<ItemTemplate>(){},
                    "file/string/path"
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
        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}