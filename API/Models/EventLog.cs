using System;
using API.Enums;

namespace API.Models
{
    public class EventLog
    {
        User User;
        DateTime Timestamp;
        String Description;
        EventType Type;
    }
}