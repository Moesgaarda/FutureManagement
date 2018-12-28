using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class TemplateCategoryForAddDto
    {
        public string Name {get; set;}
        public ICollection <ItemTemplate> ItemTemplates {get; set;}
    }
}