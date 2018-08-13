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
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public interface IEventLogRepository
    {
        Task<List<EventLog>> GetAllEventLogs();
        Task<List<EventLog>> GetEventLogs(int id);
        Task<bool> AddEventLogOrder(EventType action, Order order);
        Task<bool> AddEventLogItem(EventType action, Item item);
        Task<bool> AddEventLogItemTemplate(EventType action, ItemTemplate itemTemplate);
        Task<bool> AddEventLogUser(EventType action, User user);
        Task<bool> AddEventLogProject(EventType action, Project project);
        Task<bool> AddEventLogCustomer(EventType action, Customer customer);
        Task<bool> AddEventLogCalendarEvent(EventType action, CalendarEvent calenderEvent);

        string GetAction(EventType action);

        Task<User> GetCurrentUser();
    }
}