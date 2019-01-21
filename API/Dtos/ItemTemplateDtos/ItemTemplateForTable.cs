using System.Collections.Generic;
using API.Enums;
using API.Models;

namespace API.Dtos
{
    public class ItemTemplateForTableDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Files { get; set; }
        public System.DateTime Created { get; set; }
        public ItemTemplate RevisionedFrom;
        public ItemTemplateCategory Category;
        public int LowerLimit { get; set; }
    }
}