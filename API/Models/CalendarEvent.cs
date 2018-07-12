using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models
{
    public class CalendarEvent
    {
        public CalendarEvent(int id, CalendarEventType eventType, string name, string description, DateTime startTime, DateTime endTime, bool repeats, int repeatedInterval, User createdBy, List<User> participants){
                Id = id;
                EventType = eventType;
                Name = name;
                Description = description;
                StartTime = startTime;
                EndTime = endTime;
                Repeats = repeats;
                RepeatedInterval = repeatedInterval;
                CreatedBy = createdBy;
                Participants = participants;
        }

        public CalendarEvent(CalendarEventType eventType, string name, string description, DateTime startTime, 
            DateTime endTime, bool repeats, int repeatedInterval, User createdBy, List<User> participants){
                EventType = eventType;
                Name = name;
                Description = description;
                StartTime = startTime;
                EndTime = endTime;
                Repeats = repeats;
                RepeatedInterval = repeatedInterval;
                CreatedBy = createdBy;
                Participants = participants;
        }

        public int Id { get; }

        [Required]
        public CalendarEventType EventType { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public bool Repeats { get; set; }
        public int RepeatedInterval { get; set; }
        public User CreatedBy { get; set; }
        public List<User> Participants { get; set; }
    }
}