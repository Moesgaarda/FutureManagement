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
using Microsoft.AspNetCore.Identity;
using Moq;
using AutoMapper;

namespace API.TESTS
{
    public class AuthTest : IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        public AuthTest(){
            var store = new Mock<IUserStore<User>>();
            var _userManager = new Mock<UserManager<User>>(store.Object);
            var _signInManager = new Mock<SignInManager<User>>(store.Object);

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
            var controller = new AuthController(_config, _mapper, _userManager, _signInManager);

            var userLoginDto = new UserForLoginDto("admin", "password");
            var user = new UserForRegisterDto("admin", "password");

            await controller.Register(user);

            var tokenString = await controller.Login(userLoginDto);

            Assert.NotNull(tokenString);
        }


        [Fact]
        public async void UserSuccesfulRegisterTest(){
            var repo = new AuthRepository(_dbContext);
            var controller = new AuthController(_config, _mapper, _userManager, _signInManager);

            var userRegisterDto = new UserForRegisterDto("testuser","testPassword");

            await controller.Register(userRegisterDto);
            Assert.NotNull(_dbContext.Users.FirstOrDefault(x => x.UserName == "testuser"));
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

        [Fact]
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
                    "Jan",
                    "Krabbe",
                    new DateTime(1980, 1, 18),
                    true
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