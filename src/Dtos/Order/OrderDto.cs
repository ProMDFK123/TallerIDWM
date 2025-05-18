namespace TallerIDWM.Src.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required Models.ShippingAddress ShippingAddress { get; set; } // TODO: Revisar si es required o no
        public decimal Total { get; set; }
        public List<OrderItemDto> Items { get; set; } = [];
    }
}
