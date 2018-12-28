using System.Collections.Generic;

namespace API.Models
{
    public class ProjectStatus : Status
    {
        public ICollection<Project> Projects { get; set; }
    }
}