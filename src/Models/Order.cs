using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public Address1 ShippingAddress { get; set; } = null!;
        public decimal Total { get; set; }
        public string Status { get; set; } = "Creado";
        public List<OrderItem> Items { get; set; } = new();
    }
}