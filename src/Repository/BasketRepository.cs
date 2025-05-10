using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Data;
using api.src.Interfaces;
using api.src.Models;

using Microsoft.EntityFrameworkCore;

namespace TallerIDWM.src.Repositories
{
    public class BasketRepository(DataContext context) : IBasketRepository
    {
        private readonly DataContext _context = context;

        public async Task<Basket?> GetBasketAsync(string basketId)
        {
            return await _context.Baskets
                .Include(x => x.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(x => x.BasketId == basketId);
        }

        public Basket CreateBasket(string basketId)
        {
            var basket = new Basket { BasketId = basketId };
            _context.Baskets.Add(basket);
            return basket;
        }

        public void UpdateBasket(Basket basket)
        {
            _context.Baskets.Update(basket);
        }

        public void DeleteBasket(Basket basket)
        {
            _context.Baskets.Remove(basket);
        }



    }
}