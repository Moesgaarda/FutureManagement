using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface ICalendarRepository
    {
        Task<List<Calendar>> GetCalendars();  
        Task<Calendar> GetCalendar(int id);
        Task<List<CalendarEvent>> GetCalendarEvents(int calendarId);
        Task<List<CalendarEvent>> GetCalendarEvents(int calendarId, DateTime fromDate, DateTime toDate);
        Task<bool> AddUsersToEvent(List<int> userIds, CalendarEvent calendarEvent);
        Task<bool> EditUsersForEvent(List<int> userIds, CalendarEvent calendarEvent);
        Task<bool> AddCalendar(Calendar calendar);
        Task<bool> AddCalendarEvent(int calendarId, CalendarEvent calendarEvent);
        Task<bool> EditCalendar(Calendar calendar);
        Task<bool> EditCalendarEvent(CalendarEvent calendarEvent);
        Task<bool> DeleteCalendar(int calendarId);
        Task<bool> DeleteCalendarEvent(int calendarEventId);
    }
}