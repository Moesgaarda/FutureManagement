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
using System.Net;
using System.Net.Sockets;

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
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} kalenderbegivenhed \"{calendarEvent.Name}\" med ID[{calendarEvent.Id}]";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }

        public async Task<bool> AddEventLogCustomer(EventType action, Customer customer)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} kunde \"{customer.Name}\" med ID[{customer.Id}]";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }

        public async Task<bool> AddEventLogItem(EventType action, Item item)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} genstand \"{item.Template.Name}\" med ID[{item.Id}]";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }

        public async Task<bool> AddEventLogItemTemplate(EventType action, ItemTemplate itemTemplate)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} skabelon \"{itemTemplate.Name}\" med ID[{itemTemplate.Id}]";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }
        public async Task<bool> AddEventLogItemPropertyName(EventType action, ItemPropertyName itemPropertyName)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} egenskaben \"{itemPropertyName.Name}\"";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }

        public async Task<bool> AddEventLogOrder(EventType action, Order order)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} ordre fra \"{order.Company}\" med købsnummer[{order.PurchaseNumber}]";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }

        public async Task<bool> AddEventLogProject(EventType action, Project project)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} projekt for kunde \"{project.Customer.Name}\" med ID[{project.Id}]";
            
            int result = await WriteEvent(currUser, desc);

            return result < 0;
        }

        public async Task<bool> AddEventLogUser(EventType action, User user)
        {
            User currUser = await GetCurrentUser();
            string desc = $"Bruger \"{currUser.UserName}\" {GetAction(action)} bruger \"{user.UserName}\" med ID[{user.Id}]";
            
            int result = await WriteEvent(currUser, desc);

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
            return await _context.EventLogs.Include(x => x.User).ToListAsync();
            
        }

        public async Task<User> GetCurrentUser()
        {
            // Try-catch blok is here because the login is not fully implemented,
            // so it can not find the currently logged in user.
            // TODO Implement this when login is implement  
            try{
                int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                User user = await _userRepo.GetUser(userId);

                return user;
            }catch(Exception e){
                return await _userRepo.GetUser(1);
            }
        }

        public async Task<List<EventLog>> GetEventLogs(int id)
        {
            return await _context.EventLogs.Include(x => x.User).Where(x => x.UserId == id).ToListAsync();
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Ingen IP-adresse fundet";
        }

        private async Task<int> WriteEvent(User currUser, string desc){
            string ip = GetLocalIPAddress();
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc, ip);
            
            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}