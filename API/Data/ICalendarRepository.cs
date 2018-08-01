using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface ICalendarRepository
    {
        Task<List<Calendar>> GetCalendars();  
        Task<Calendar> GetCalendar(int id);
        Task<List<CalendarEvent>> GetCalendarEvents(int CalendarId);
        Task<bool> AddUsersToEvent(List<int> userIds, CalendarEvent calendarEvent);
        Task<bool> EditUsersForEvent(List<int> userIds, CalendarEvent calendarEvent);
        Task<bool> AddCalendar(Calendar calendar);
        Task<bool> AddCalendarEvent(CalendarEvent calendarEvent);
        Task<bool> EditCalendar(Calendar calendar);
        Task<bool> EditCalendarEvent(CalendarEvent calendarEvent);
        Task<bool> DeleteCalendar(Calendar calendar);
        Task<bool> DeleteCalendarEvent(CalendarEvent calendarEvent);
    }
}