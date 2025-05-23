namespace TallerIDWM.Src.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public required string BasketId { get; set; }

        public List<BasketItem> Items { get; set; } = [];

        public void AddItem(Product product, int quantity)
        {
            if (product == null)
                ArgumentNullException.ThrowIfNull(product);
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0 ", nameof(quantity));

            var existingItem = FindItem(product.Id);

            if (existingItem == null)
            {
                Items.Add(new BasketItem { Quantity = quantity, Product = product });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        public void UpdateItemQuantity(int productId, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity must be 0 or greater", nameof(quantity));

            var item = FindItem(productId);
            if (item == null)
                return;

            if (quantity == 0)
            {
                Items.Remove(item); // si es 0, se elimina el producto del carrito
            }
            else
            {
                item.Quantity = quantity; // si es mayor, se actualiza la cantidad
            }
        }

        public void RemoveItem(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0 ", nameof(quantity));
            var item = FindItem(productId);

            if (item == null)
                return;

            item.Quantity -= quantity;

            if (item.Quantity <= 0)
            {
                Items.Remove(item);
            }
        }

        private BasketItem? FindItem(int productId)
        {
            return Items.FirstOrDefault(item => item.ProductId == productId);
        }
    }
}
