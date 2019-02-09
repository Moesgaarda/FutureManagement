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
    public class EventLogTest : IDisposable
    {
        private readonly DataContext _dbContext;

        private readonly IEventLogRepository _repo;

        public EventLogTest(){
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

            _repo = new EventLogRepository(_dbContext);
        }

        [Fact]
        public async void GetAllEventLogsTest(){
            var eventLogController = new EventLogsController(_dbContext, _repo);

            IActionResult allEventLogs = await eventLogController.GetAllEventLogs();
            OkObjectResult intermediate = allEventLogs as OkObjectResult;
            List<EventLog> result = intermediate.Value as List<EventLog>;
            // Assert
            Assert.True(result.Count == 2);
        }

        [Fact]
        public async void GetUserEventLogsReturnsTwoTest(){
            var eventLogController = new EventLogsController(_dbContext, _repo);

            var user = _dbContext.Users.FirstAsync(x => x.Id == 1);

            IActionResult userEventLogs = await eventLogController.GetUserEventLog(user.Id);
            OkObjectResult intermediate = userEventLogs as OkObjectResult;
            List<EventLog> result = intermediate.Value as List<EventLog>;
            // Assert
            Assert.True(result.Count == 2);
        }

        
        [Fact]
        public async void GetUserEventLogsReturnsNoneTest(){
            var eventLogController = new EventLogsController(_dbContext, _repo);

            IActionResult userEventLogs = await eventLogController.GetUserEventLog(2);
            OkObjectResult intermediate = userEventLogs as OkObjectResult;
            List<EventLog> result = intermediate.Value as List<EventLog>;
            // Assert
            Assert.Null(result.Count == 0);
        }

                
        [Fact]
        public async void GetMyEventLogsNotLoggedInTest(){
            var eventLogController = new EventLogsController(_dbContext, _repo);


            IActionResult userEventLogs = await eventLogController.GetMyEventLogs(1);
            StatusCodeResult status = userEventLogs as StatusCodeResult;
            var result = new StatusCodeResult(401);
            // Assert
            Assert.True(status.StatusCode == result.StatusCode);
        }

        // TODO lav en test hvor man er logged ind og prøver at hente sine egne eventLogs

        private void Seed(DataContext context){

            var user1 =
                new User(
                    "Jan",
                    "Krabbe",
                    new DateTime(1980, 1, 18),
                    true
                    );
            
            context.Users.Add(user1);
            context.SaveChangesAsync();

            var userToInsert = context.Users.First(x => x.Id == 1);

            var eventLogs = new[]{
                new EventLog(userToInsert, userToInsert.Id, "Dette er en test af EventLog", "some IP address"),
                new EventLog(userToInsert, userToInsert.Id, "Dette er OGSÅ en test af eventLog", "some IP address")
            };
            context.AddRange(eventLogs);
            context.SaveChangesAsync();
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}