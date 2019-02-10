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
using Microsoft.AspNetCore.Identity;

namespace API.TESTS
{
    public class ItemTemplateTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IItemTemplateRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly EventLogRepository _eventLogRepo;
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
            var con = new ItemTemplateController(_repo, _dbContext, _mapper, _userManager, _eventLogRepo);

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
            var con = new ItemTemplateController(_repo, _dbContext, _mapper, _userManager, _eventLogRepo);

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
            var con = new ItemTemplateController(_repo, _dbContext, _mapper, _userManager, _eventLogRepo);
            //When

            IActionResult templateResult = await con.GetItemTemplate(1);
            //Then

            OkObjectResult template = templateResult as OkObjectResult;
            ItemTemplateForGetDto temp = template.Value as ItemTemplateForGetDto;


            Assert.Equal(temp.Id, 1);
        }

        [Fact]
        public async void AddTemplateTest()
        {
            //Given
            var listTP = new List<TemplatePropertyRelation>();
            listTP.AddRange(_dbContext.TemplatePropertyRelations.Where(x => x.TemplateId == 1));
            listTP.AddRange(_dbContext.TemplatePropertyRelations.Where(x => x.TemplateId == 2));


            var con = new ItemTemplateController(_repo, _dbContext, _mapper, _userManager, _eventLogRepo);
            var template = new ItemTemplate(
                "Dør",
                new UnitType
                {
                    Name = "test"
                },
                "Dette er en Dør",
                listTP,
                new List<ItemTemplatePart>() { },
                new List<ItemTemplatePart>() { },
                new DateTime { },
                new ItemTemplate { },
                new List<TemplateFileName>(),
                0,
                new ItemTemplateCategory { }
            );
            //When
            await con.AddItemTemplate(_mapper.Map<ItemTemplateForAddDto>(template));
            var dbTemplate = _dbContext.ItemTemplates.FirstOrDefault(x => x.Name == "Dør");
            //Then
            Assert.True(dbTemplate.Name == template.Name);
        }

        [Fact]
        public async void AddTemplateReturnTest()
        {
            //Given
            var con = new ItemTemplateController(_repo, _dbContext, _mapper, _userManager, _eventLogRepo);

            var listTP = new List<TemplatePropertyRelation>();
            listTP.AddRange(_dbContext.TemplatePropertyRelations.Where(x => x.TemplateId == 1));
            listTP.AddRange(_dbContext.TemplatePropertyRelations.Where(x => x.TemplateId == 2));

            var template = new ItemTemplate(
                "Dør",
                new UnitType
                {
                    Name = "test"
                },
                "Dette er en Dør",
                listTP,
                new List<ItemTemplatePart>() { },
                new List<ItemTemplatePart>() { },
                new DateTime { },
                new ItemTemplate { },
                new List<TemplateFileName>(),
                0,
                new ItemTemplateCategory { }
            );
            //When
            var status = await con.AddItemTemplate(_mapper.Map<ItemTemplateForAddDto>(template));
            StatusCodeResult result = status as StatusCodeResult;
            var test = new StatusCodeResult(201);
            Assert.True(result.StatusCode == test.StatusCode);
        }


        private void Seed(DataContext context)
        {
            var listTP = new List<TemplatePropertyRelation>();
            listTP.AddRange(_dbContext.TemplatePropertyRelations.Where(x => x.TemplateId == 1));
            listTP.AddRange(_dbContext.TemplatePropertyRelations.Where(x => x.TemplateId == 2));

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
                "Dør",
                new UnitType{
                    Name = "test"
                },
                "Dette er en Dør",
                listTP,
                new List<ItemTemplatePart>() { },
                new List<ItemTemplatePart>() { },
                new DateTime {},
                new ItemTemplate{},
                new List<TemplateFileName>(),
                0,
                new ItemTemplateCategory{}
            ),
                new ItemTemplate(
                "Dør1",
                new UnitType{
                    Name = "test"
                },
                "Dette er en Dør",
                listTP,
                new List<ItemTemplatePart>() { },
                new List<ItemTemplatePart>() { },
                new DateTime {},
                new ItemTemplate{},
                new List<TemplateFileName>(),
                0,
                new ItemTemplateCategory{}
            ),
                new ItemTemplate(
                "Dør2",
                new UnitType{
                    Name = "test"
                },
                "Dette er en Dør",
                listTP,
                new List<ItemTemplatePart>() { },
                new List<ItemTemplatePart>() { },
                new DateTime {},
                new ItemTemplate{},
                new List<TemplateFileName>(),
                0,
                new ItemTemplateCategory{}
            )
            };
            context.ItemTemplates.AddRange(itemTemplates);
            context.SaveChanges();
            var users = new[]{
                new User(
                    "Jan",
                    "Krabbe",
                    new DateTime(1980, 1, 18),
                    true
                    )
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            var orders = new[]{
                new Order("CompanyA",
                    DateTime.Today,
                    DateTime.Now,
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    1,
                    123,
                    456,
                    789,
                    new UnitType {},
                    new List<Item>(),
                    new List<OrderFileName>(),
                    OrderStatusEnum.Ankommet
                ),
                new Order("CompanyB",
                    DateTime.Today,
                    DateTime.Now,
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    1,
                    123,
                    456,
                    789,
                    new UnitType {},
                    new List<Item>(),
                    new List<OrderFileName>(),
                    OrderStatusEnum.Annulleret
                )
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
                    new List<ItemItemRelation>(),
                    new List<ItemItemRelation>(),
                    false
                ),
                new Item(
                    "41d",
                    11,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 2),
                    context.Orders.FirstOrDefault(x => x.Id == 1),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemPropertyDescription>(){context.ItemPropertyDescriptions.FirstOrDefault(X => X.Id == 2)},
                    new List<ItemItemRelation>(),
                    new List<ItemItemRelation>(),
                    false
                ),
                new Item(
                    "40d",
                    12,
                    context.ItemTemplates.FirstOrDefault(x => x.Id == 3),
                    context.Orders.FirstOrDefault(x => x.Id == 2),
                    context.Users.FirstOrDefault(x => x.Id == 1),
                    new List<ItemPropertyDescription>(){context.ItemPropertyDescriptions.FirstOrDefault(X => X.Id == 1)},
                    new List<ItemItemRelation>(),
                    new List<ItemItemRelation>(),
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