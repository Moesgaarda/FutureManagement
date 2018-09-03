using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class ItemItemRelationForGet
    {
        public int PartId { get; set; }
        public int Amount { get; set; }
        public ItemTemplateForItemGetDto Template { get; set; }
    }
}