using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket?> GetBasketAsync(string basketId);
        Basket CreateBasket(string basketId);
        void UpdateBasket(Basket basket);
        void DeleteBasket(Basket basket);
    }
}
