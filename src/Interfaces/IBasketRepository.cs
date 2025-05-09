using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Models;

namespace api.src.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket?> GetBasketAsync(string basketId);
        Basket CreateBasket(string basketId);
        void UpdateBasket(Basket basket);
        void DeleteBasket(Basket basket);

    }
}