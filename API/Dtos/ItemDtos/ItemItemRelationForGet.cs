using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class ItemItemRelationForGet
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public ItemTemplate Template { get; set; }
    }
}