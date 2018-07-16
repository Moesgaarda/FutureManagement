using System;
using Xunit;
using API;
using API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace API.TESTS
{
        

    public class APIUnitTest : IDisposable
    {
        private readonly DbContext _DbContext;

        public APIUnitTest(){
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _DbContext = new DbContext(options);
            _DbContext.Database.EnsureCreated();
            Seed(_DbContext);
        }

        private void Seed(DbContext context){
            //TODO Seed this
        }

        public void Dispose(){
            _DbContext.Database.EnsureDeleted();
            _DbContext.Dispose();
        }
    }
}
