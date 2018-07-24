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
    public class ItemTemplateTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IItemTemplateRepository _repo;
        public ItemTemplateTest()
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
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemTemplate, ItemTemplateForGetDto>();
                cfg.CreateMap<ItemTemplate, ItemTemplateForAddDto>();
                cfg.CreateMap<ItemTemplate, ItemTemplateForTableDto>();

            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async void GetAllTemplatesTest()
        {
            //Arrange
            var con = new ItemTemplateController(_repo, _dbContext, _mapper);

            //Act
            IActionResult allItems = await con.GetItemTemplates();
            OkObjectResult intermediate = allItems as OkObjectResult;
            List<ItemTemplateForTableDto> result = intermediate.Value as List<ItemTemplateForTableDto>;

            //Asserty
            Assert.True(result.Count == 3);
        }

        [Fact]
        public async void GetAllTemplatesFalseTest()
        {
            //Arrange
            var con = new ItemTemplateController(_repo, _dbContext, _mapper);

            //Act
            IActionResult allItems = await con.GetItemTemplates();
            OkObjectResult intermediate = allItems as OkObjectResult;
            List<ItemTemplateForTableDto> result = intermediate.Value as List<ItemTemplateForTableDto>;

            //Asserty
            Assert.False(result.Count != 3);
        }

        [Fact]
        public async void ShowDetailsTemplateTest()
        {
            //Given
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            //When

            IActionResult templateResult = await controller.GetItemTemplate(1);
            //Then

            OkObjectResult template = templateResult as OkObjectResult;
            ItemTemplateForGetDto temp = template.Value as ItemTemplateForGetDto;


            Assert.Equal(temp.Id, 1);
        }

        [Fact]
        public async void AddTemplateTest()
        {
            //Given
            var listTP = new List<TemplateProperty>();
            listTP.AddRange(_dbContext.TemplateProperties.Where(x => x.TemplateId == 1));
            listTP.AddRange(_dbContext.TemplateProperties.Where(x => x.TemplateId == 2));


            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            var template = new ItemTemplate(
                "Dør",
                UnitType.m,
                "Dette er en Dør",
                listTP,
                new List<ItemTemplatePart>() { },
                "file/string/path"
            );
            //When
            await controller.AddItemTemplate(_mapper.Map<ItemTemplateForAddDto>(template));
            var dbTemplate = _dbContext.ItemTemplates.FirstOrDefault(x => x.Name == "Dør");
            //Then
            Assert.True(dbTemplate.Name == template.Name);
        }

        [Fact]
        public async void AddTemplateReturnTest()
        {
            //Given
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            var template = new ItemTemplate(
                "Dør",
                UnitType.m,
                "Dette er en Dør",
                new List<TemplateProperty>() { },
                null,
                "file/string/path"
            );
            //When
            var status = await controller.AddItemTemplate(_mapper.Map<ItemTemplateForAddDto>(template));
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(201);
            Assert.True(result.StatusCode == test.StatusCode);
        }

        [Fact]
        public async void EditTemplateTest()
        {
            //Arrange
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            template.Description = "En Ny beskrivelse";
            await controller.EditItemTemplate(template);
            var editedTemplate = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Assert
            Assert.True(
                editedTemplate.Description == template.Description
                );
        }


        [Fact]
        public async void EditTemplateReturnTest()
        {
            //Arrange
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            template.Description = "En Ny beskrivelse";
            template.TemplateProperties.Concat(_dbContext.TemplateProperties.Where(x => x.TemplateId == 3));
            var status = await controller.EditItemTemplate(template);
            //Assert
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(200);
            Assert.True(result.StatusCode == test.StatusCode);
        }

        /*    kom her til med at fixe, alt over er fint*/
        [Fact]
        public async void DeleteTemplateTest()
        {
            //Arrange
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            await controller.DeleteItemTemplate(template.Id);
            //Assert
            var test = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            Assert.Null(test);
        }

        [Fact]
        public async void DeleteTemplateReturnTrueTest()
        {
            //Arrange
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            var template = _dbContext.ItemTemplates.FirstOrDefault(x => x.Id == 1);
            //Act
            var status = await controller.DeleteItemTemplate(template.Id);
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(200);
            //Assert
            Assert.True(result.StatusCode == test.StatusCode);
        }
        [Fact]
        public async void DeleteTemplateReturnFalseTest()
        {
            //Arrange
            var controller = new ItemTemplateController(_repo, _dbContext, _mapper);
            //Act
            var status = await controller.DeleteItemTemplate(0);
            BadRequestObjectResult result = status as BadRequestObjectResult;
            var test = new StatusCodeResult(200);
            //Assert
            Assert.False(result.StatusCode == test.StatusCode);
        }

        private void Seed(DataContext context)
        {
            var listTP = new List<TemplateProperty>();
            listTP.AddRange(_dbContext.TemplateProperties.Where(x => x.TemplateId == 1));
            listTP.AddRange(_dbContext.TemplateProperties.Where(x => x.TemplateId == 2));

            var itemProperties = new[]{
                new ItemPropertyDescription(1,"gul"),
                new ItemPropertyDescription(2,"halv"),
                new ItemPropertyDescription(3,"slebet")
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
                    listTP,
                    new List<ItemTemplatePart>(){},
                    "file/string/path"
                ),
                new ItemTemplate(
                    "stang",
                    UnitType.m,
                    "Dette er en stang",
                    listTP,
                    new List<ItemTemplatePart>(){},
                    "file/string/path"
                ),
                new ItemTemplate(
                    "tagplade",
                    UnitType.m,
                    "Dette er en tagplade",
                    listTP,
                    new List<ItemTemplatePart>(){},
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
                    new List<ItemPropertyDescription>(){context.ItemPropertyDescriptions.FirstOrDefault(X => X.Id == 1)},
                    new List<Item>(),
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