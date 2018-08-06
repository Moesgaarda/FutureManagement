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

namespace API.TESTS
{
    public class CalendarTest : IDisposable{
        private readonly DataContext _dbContext;

        public CalendarTest(){
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

        private void Seed(DataContext context){
            var johnUser = new User(
                "JohnUser",
                new UserRole("Office worker"),
                "John",
                "Officeson",
                DateTime.MinValue,
                true,
                "john@officeworker.org",
                "15485926"
            );

            var testEvent = new []{
                new CalendarEvent(
                CalendarEventType.work,
                "John busy",
                "John out of office",
                DateTime.MinValue,
                DateTime.MaxValue,
                false,
                1, // Fix interval
                johnUser
            ),
                new CalendarEvent(
                CalendarEventType.notwork,
                "John tennis",
                "John out of office to play tennis",
                DateTime.MinValue,
                DateTime.MaxValue,
                false,
                1, // Fix interval
                johnUser
            )};

            var calendars = new[]{
                new Calendar(
                    "Work",
                    testEvent
                ),
                new Calendar(
                    "Birthdays"
                )
            };

            context.Calendars.AddRange(calendars);
            context.SaveChanges();
        }

        public void Dispose(){
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Fact]
        public void CreateEventTest(){
            throw new NotImplementedException();
        }

        [Fact]
        public void CreateEventReturnsTrueTest(){
            throw new NotImplementedException();
        }

        [Fact]
        public void CreateCalendarTest(){
            throw new NotImplementedException();
        }

        [Fact]
        public void CreateCalendarTestReturnsTrueTest(){
            throw new NotImplementedException();
        }

        [Fact]
        public void AddUserToEventTest()
        {
        }

        [Fact]
        public void AddMultipleUsersToEventTest()
        {
        }

        [Fact]
        public void GetCalendarEventsTest()
        {
        }

        [Fact]
        public void EditCalendarEventTest()
        {

        }

        [Fact]
        public void EditCalendarTest()
        {
        //Given
        
        //When
        
        //Then
        }
        
        [Fact]
        public void DeleteCalendarTest()
        {
        //Given
        
        //When
        
        //Then
        }

        [Fact]
        public void DeleteCalendarEventTest()
        {
        //Given
        
        //When
        
        //Then
        }

        [Fact]
        public void EditUsersForEventTest()
        {
        //Given
        
        //When
        
        //Then
        }
    }
}