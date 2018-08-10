using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Enums;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace API.Data
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EventLogRepository(DataContext context){
            this._context = context;
            this._userRepo = new UserRepository(_context);
            this._httpContextAccessor = new HttpContextAccessor();
        }

        public async Task<bool> AddEventLogCalendarEvent(EventType action, CalendarEvent calendarEvent)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} kalenderbegivenhed \"{calendarEvent.Name}\" med ID[{calendarEvent.Id}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<bool> AddEventLogCustomer(EventType action, Customer customer)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} kunde \"{customer.Name}\" med ID[{customer.Id}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<bool> AddEventLogItem(EventType action, Item item)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} genstand \"{item.Template.Name}\" med ID[{item.Id}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<bool> AddEventLogItemTemplate(EventType action, ItemTemplate itemTemplate)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} skabelon \"{itemTemplate.Name}\" med ID[{itemTemplate.Id}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<bool> AddEventLogOrder(EventType action, Order order)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} ordre fra \"{order.Company}\" med købsnummer[{order.PurchaseNumber}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<bool> AddEventLogProject(EventType action, Project project)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} projekt for kunde \"{project.Customer.Name}\" med ID[{project.Id}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<bool> AddEventLogUser(EventType action, User user)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger {currUser.Username} {GetAction(action)} bruger \"{user.Username}\" med ID[{user.Id}]";
            
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public string GetAction(EventType action)
        {
            string result = "";

            if(action == EventType.Changed){
                result = "ændrede";
            }
            else if(action == EventType.Created){
                result = "tilføjede";
            }
            else if(action == EventType.Delete){
                result = "slettede";
            }
            return result;
        }

        public async Task<List<EventLog>> GetAllEventLogs()
        {
            return await _context.EventLogs.ToListAsync();
            
        }

        public async Task<User> GetCurrentUser()
        {
            // Try-catch blok is here because the login is not fully implemented,
            // so it can not find the currently logged in user.
            try{
                int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                User user = await _userRepo.GetUser(userId);

                return user;
            }catch(NullReferenceException){
                return new User(){ Username = "unauthorized user"};
            }
        }

        public async Task<List<EventLog>> GetEventLogs(int id)
        {
            return await _context.EventLogs.Where(x => x.UserId == id).ToListAsync();
        }
    }
}