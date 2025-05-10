using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Interfaces;
using Bogus.DataSets;

namespace api.src.Data;

public class UnitOfWork(DataContext context, IProductRepository productRepository, IUserRepository userRepository, IBasketRepository basketRepository,IAddress1Repository Address1Repository) 
{
    private readonly DataContext _context = context;
    public IUserRepository UserRepository { get; set; } = userRepository;
    public IProductRepository ProductRepository { get; set; } = productRepository;
    public IBasketRepository BasketRepository { get; set; } = basketRepository;
    public IAddress1Repository Address1Repository { get; set; } = Address1Repository;
    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }

}