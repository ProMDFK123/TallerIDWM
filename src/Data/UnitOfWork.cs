using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Interfaces;
using api.src.Data;

namespace api.src.Data;
public class UnitOfWork(DataContext context, IProductRepository productRepository, IAddress1Repository address1Repository, IUserRepository userRepository)
{
    private readonly DataContext dataContext = context;
    public IProductRepository ProductRepository { get; } = productRepository;
    public IAddress1Repository Address1Repository { get; } = address1Repository;
    public IUserRepository UserRepository { get; } = userRepository;

    public async Task SaveChangesAsync()
    {
        await dataContext.SaveChangesAsync();
    }
}