using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Enums;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace API.TESTS
{
    public class ProjectTest : IDisposable  
    {
        private readonly DataContext _dbContext;
        public ProjectTest()
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
        }
        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Fact]
        public void GetCustomerShouldReturnResult()
        {
            Assert.True(_dbContext.Projects.Any(x => x.Customer.Name == "morfar"));
        
        }
        [Fact]
        public void GetCustomerShouldFail(){
            Assert.True(false);
        }
        private void Seed(DataContext dbContext){
                Customer c1 = new Customer();
                Calculator cal1 = new Calculator();
                ItemProperty ip1 = new ItemProperty(1,"bla");
                List<ItemProperty> ipList = new List<ItemProperty>();
                ipList.Add(ip1);
                ItemPropertyCategory ipc1 = new ItemPropertyCategory(1,"bla");
                var ipcList = new List<ItemPropertyCategory>();
                ipcList.Add(ipc1);
                ItemTemplate it1 = new ItemTemplate(1,"something", UnitType.mm,"blabla",ipcList,null);
                User u1 = new User();
                Order o1 = new Order("morfarCompany",DateTime.Now,DateTime.MaxValue,u1,"invoice",13,12,11,10,UnitType.cm,null);
                Item i1 = new Item(1,ipList,"2d",3,it1,o1,u1,null);

            var projects = new[]{
                new Project(1,c1,DateTime.Now,DateTime.MaxValue,null, "morfarsCrib","morfar land", "this is a comment",13,cal1, Status.Bestilt,1,2,3,UnitType.cm,"usage",100,"methoddecl")

            };
            dbContext.Projects.AddRange(projects);
            dbContext.SaveChanges(); 
        }
    }
}