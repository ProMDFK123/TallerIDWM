using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Address1 ShippingAddress { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemDto> Items { get; set; } = [];
    }
}