using System;
using System.Collections.Generic;
using API.Dtos.FileDtos;
using API.Enums;
using API.Models;

namespace API.Dtos.OrderDtos
{
    public class OrderForGetDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public UserForItemGetDto OrderedBy { get; set; }
        public int PurchaseNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public UnitType UnitType { get; set; }
        public ICollection<ItemForTableGetDto> Products { get; set; }
        public ICollection<FileNameForGetDto> Files { get; set; }
        public OrderStatusEnum Status { get; set; }
        public bool InternalOrder { get; set; }

        /* If the order is internal, it should have an assigned user */
        public UserForItemGetDto AssignedUser { get; set; }
        public UserForItemGetDto SignedBy { get; set; }
    }
}