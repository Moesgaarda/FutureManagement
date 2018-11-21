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
        string GetAction(EventType action);
        Task<bool> AddEventLog(EventType action, string objectType, string objectName, int objectId, User currentUser);
        Task<bool> AddEventLogChange<T>(string objectType, String objectName, int objectId, User currentUser, T objectOld, T objectNew);

    }
}