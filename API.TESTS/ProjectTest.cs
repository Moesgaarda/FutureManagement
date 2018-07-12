using System;
using System.Linq;
using API.Data;
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
           // Assert.True(_dbContext.Projects.Any(x => x.Customer.Name == "morfar"));
        
        }
        [Fact]
        public void GetCustomerShouldFail(){
            //Assert.True(false);
        }
        private void Seed(DataContext dbContext){
            /* var projects = new[]{
                new Project {Customer = new Customer{Name = "morfar"}}

            };
            dbContext.Projects.AddRange(projects);
            dbContext.SaveChanges(); */
        }
    }
}