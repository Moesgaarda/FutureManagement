using System.Collections.Generic;

namespace API.Models
{
    public class ProjectStatus : Status
    {
        // TODO This should be an enum before it hits production
        public ICollection<Project> Projects { get; set; }
    }
}