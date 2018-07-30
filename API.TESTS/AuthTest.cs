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
using Microsoft.Extensions.Configuration.FileExtensions;
using System.IO;

namespace API.TESTS
{
    public class AuthTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IConfiguration _config;

        public AuthTest(){
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

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _config = builder.Build();
        }

        [Fact]
        public async void LoginSuccesfulTest(){
            var repo = new AuthRepository(_dbContext);
            var controller = new AuthController(repo, _config);

            var userLoginDto = new UserForLoginDto("admin", "password");
            var user = new UserForRegisterDto("admin", "password");

            await controller.Register(user);

            var tokenString = await controller.Login(userLoginDto);

            Assert.NotNull(tokenString);
        }


        [Fact]
        public async void UserSuccesfulRegisterTest(){
            var repo = new AuthRepository(_dbContext);
            var controller = new AuthController(repo, _config);

            var userRegisterDto = new UserForRegisterDto("testuser","testPassword");

            await controller.Register(userRegisterDto);
            Assert.NotNull(_dbContext.Users.FirstOrDefault(x => x.Username == "testuser"));
        }

        [Fact]
        public async void UserExistTest(){
            var repo = new AuthRepository(_dbContext);

            var userExists = await repo.UserExists("jankrabbe");

            Assert.True(userExists);
        }

        [Fact]
        public async void UserDoesNotExistTest(){
            var repo = new AuthRepository(_dbContext);

            var userExists = await repo.UserExists("thisuserdoesnotexist");

            Assert.False(userExists);
        }

        public void PasswordHashTest(){
            var repo = new AuthRepository(_dbContext);

            String password = "somepassword";
            byte[] passwordHash = new byte[]{};
            byte[] passwordSalt = new byte[]{};
            repo.CreatePasswordHash(password, out passwordHash, out  passwordSalt);
            bool passwordMatches = repo.VerifyPasswordHash(password, passwordHash, passwordSalt);

            Assert.True(passwordMatches);
        }

        private void Seed(DataContext context){
            var users = new []{
                new User(
                    "jankrabbe",
                    new UserRole(1, "Admin"),
                    "jan",
                    "Krabbe",
                    new DateTime(1980, 1, 18),
                    true,
                    "Jan@FutureRundbuehaller.dk",
                    "88888888"
                    ),
                new User(
                    "geopoulsen",
                    new UserRole(2, "Kontor"),
                    "Geo",
                    "Poulsen",
                    new DateTime(1970, 5, 18),
                    false,
                    "Geo@FutureRundbuehaller.dk",
                    "55443322"
                    )
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}