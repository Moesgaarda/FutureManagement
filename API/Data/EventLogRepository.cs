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
using System.Reflection;
using API.Helpers;

namespace API.Data
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly DataContext _context;
        public EventLogRepository(DataContext context)
        {
            this._context = context;
        }

        // Used to add eventlog to the database when an object is added or activated/deactived
        public async Task<bool> AddEventLog(EventType action, string objectType, string objectName, int objectId, User currentUser)
        {

            string desc = $"Bruger \"{currentUser.UserName}\" {GetAction(action)} {objectType} \"{objectName}\" med ID[{objectId}]";

            int result = await WriteEvent(currentUser, desc);

            return result < 0;
        }

        // Used to add eventlog to the database when an object is changed
        public async Task<bool> AddEventLogChange<T>(string objectType, string objectName, int objectId, User currentUser, T objectOld, T objectNew)
        {

            List<Variance> variances = objectOld.DetailedCompare(objectNew);
            String changes = "";
            if (variances.Count > 0)
            {
                for (int i = 0; i < variances.Count; i++)
                {
                    changes += ", " + variances[i].Prop;
                }
            }

            string desc = $"Bruger \"{currentUser.UserName}\" ændrede {changes} for {objectType} \"{objectName}\" med ID[{objectId}]";

            int result = await WriteEvent(currentUser, desc);

            return result < 0;
        }

        public string GetAction(EventType action)
        {
            string result = "";

            switch (action)
            {
                case EventType.Created:
                    result = "tilføjede";
                    break;
                case EventType.Deleted:
                    result = "slettede";
                    break;
                case EventType.Activated:
                    result = "aktiverede";
                    break;
                case EventType.Deactivated:
                    result = "deaktiverede";
                    break;
            }
            return result;
        }

        public async Task<List<EventLog>> GetAllEventLogs()
        {
            return await _context.EventLogs.Include(x => x.User).ToListAsync();

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

        private async Task<int> WriteEvent(User currUser, string desc)
        {
            string ip = GetLocalIPAddress();
            EventLog eventLog = new EventLog(currUser, currUser.Id, desc, ip);

            await _context.EventLogs.AddAsync(eventLog);
            int result = await _context.SaveChangesAsync();

            return result;
        }


    }
}