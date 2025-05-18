using TallerIDWM.Src.Interfaces;

namespace TallerIDWM.Src.Data;

public class UnitOfWork(
    DataContext context,
    IProductRepository productRepository,
    IUserRepository userRepository,
    IBasketRepository basketRepository,
    IShippingAddressRepository shippingAddressRepository,
    IOrderRepository orderRepository
)
{
    private readonly DataContext _context = context;
    public IUserRepository UserRepository { get; set; } = userRepository;
    public IProductRepository ProductRepository { get; set; } = productRepository;
    public IBasketRepository BasketRepository { get; set; } = basketRepository;
    public IShippingAddressRepository ShippingAddressRepository { get; set; } =
        shippingAddressRepository;
    public IOrderRepository OrderRepository { get; set; } = orderRepository;

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
