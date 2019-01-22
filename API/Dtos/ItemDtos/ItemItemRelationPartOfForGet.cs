using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class ItemItemRelationPartOfForGet
    {
        public Item Part { get; set; }
        public int Amount { get; set; }
        public int ItemId {get; set;}
    }
}