namespace TallerIDWM.Src.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; } = null!;
        public decimal Total { get; set; }
        public string Status { get; set; } = "Creado";
        public List<OrderItem> Items { get; set; } = new();
    }
}
