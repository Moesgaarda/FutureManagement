using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly DataContext _context;
        public CalendarRepository(DataContext context){
            this._context = context;
        }

        public async Task<bool> AddCalendar(Calendar calendar)
        {
            await _context.Calendars.AddAsync(calendar);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AddCalendarEvent(int calendarId, CalendarEvent calendarEvent)
        {
            var calendar = _context.Calendars.FirstOrDefaultAsync(x => x.Id == calendarId).Result;
            calendarEvent.Calendar = calendar;

            await _context.CalendarEvents.AddAsync(calendarEvent);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public Task<bool> AddUsersToEvent(List<int> userIds, CalendarEvent calendarEvent)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCalendar(int calendarId)
        {
            Calendar calendar = await _context.Calendars.FirstOrDefaultAsync(x => x.Id == calendarId);
            _context.Calendars.Remove(calendar);

            int result = await _context.SaveChangesAsync();     
            return result > 0;
        }

        public async Task<bool> DeleteCalendarEvent(int calendarEventId)
        {
            CalendarEvent calendarEvent = await _context.CalendarEvents.FirstOrDefaultAsync(x => x.Id == calendarEventId);
            _context.CalendarEvents.Remove(calendarEvent);

            int result = await _context.SaveChangesAsync();     
            return result > 0;
        }

        public async Task<bool> EditCalendar(Calendar calendar)
        {
            var calendarToChange = _context.ItemTemplates.First(x => x.Id == calendar.Id);
            _context.Entry(calendarToChange).CurrentValues.SetValues(calendar);
            var result = await _context.SaveChangesAsync();

            return result > 0; 
        }

        public async Task<bool> EditCalendarEvent(CalendarEvent calendarEvent)
        {
            var calendarEventToChange = _context.ItemTemplates.First(x => x.Id == calendarEvent.Id);
            _context.Entry(calendarEventToChange).CurrentValues.SetValues(calendarEvent);
            var result = await _context.SaveChangesAsync();

            return result > 0; 
        }

        public Task<bool> EditUsersForEvent(List<int> userIds, CalendarEvent calendarEvent)
        {
            throw new NotImplementedException();
        }

        public async Task<Calendar> GetCalendar(int id)
        {
            return await _context.Calendars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CalendarEvent>> GetCalendarEvents(int calendarId)
        {
            return await _context.CalendarEvents.Where(x => x.Id == calendarId).ToListAsync();
        }

        public async Task<List<CalendarEvent>> GetCalendarEvents(int calendarId, DateTime fromDate, DateTime toDate)
        {
            return await _context.CalendarEvents.Where(x => x.Calendar.Id == calendarId && x.StartTime >= fromDate && x.EndTime <= toDate).ToListAsync();
        }

        public async Task<List<Calendar>> GetCalendars()
        {
            return await _context.Calendars.ToListAsync();
        }
    }
}