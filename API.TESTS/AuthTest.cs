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
using API.Dtos;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace API.TESTS
{
    public class AuthTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IConfiguration _config;

        public AuthTest(IConfiguration config){
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
            _config = config;
        }

        [Fact]
        public async void LoginSuccesfulTest(){
            var repo = new AuthRepository(_dbContext);
            var controller = new AuthController(repo, _config);

            var userDto = new UserForLoginDto("admin", "password");

            await controller.Login(userDto);

            Assert.
        }

        public async void UserSuccesfulRegisterTest(){
            var repo = new AuthRepository(_dbContext);
            var controller = new AuthController(repo, _config);

            var userDto = new UserForRegisterDto("testUser","testPassword");
        }

        private void Seed(DataContext context){
            var users = new []{
                new User(1,
                    "jankrabbe",
                    new UserRole(1, "Admin"),
                    "jan",
                    "Krabbe",
                    new DateTime(1980, 1, 18),
                    true,
                    "Jan@FutureRundbuehaller.dk",
                    88888888
                    ),
                new User(2,
                    "geopoulsen",
                    new UserRole(1, "Kontor"),
                    "Geo",
                    "Poulsen",
                    new DateTime(1970, 5, 18),
                    true,
                    "Geo@FutureRundbuehaller.dk",
                    55443322
                    )
            };
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}