using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TallerIDWM.Src.Data;
using TallerIDWM.Src.DTOs.Order;
using TallerIDWM.Src.Helpers;
using TallerIDWM.Src.Mappers;

namespace TallerIDWM.Src.Controllers;

public class OrderController(ILogger<OrderController> logger, UnitOfWork unitOfWork)
    : BaseController
{
    private readonly ILogger<OrderController> _logger = logger;
    private readonly UnitOfWork _unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<ActionResult<ApiResponse<OrderDto>>> CreateOrder()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized(new ApiResponse<string>(false, "Usuario no autenticado"));
        }

        var address = await _unitOfWork.ShippingAddressRepository.GetDefaultAddressAsync(userId);
        if (address == null)
            return BadRequest(
                new ApiResponse<string>(
                    false,
                    "No tienes una dirección registrada. Por favor, añade una dirección antes de realizar un pedido."
                )
            );

        var basketId = Request.Cookies["basketId"];
        if (string.IsNullOrEmpty(basketId))
            return BadRequest(new ApiResponse<string>(false, "No se encontró el carrito."));

        var basket = await _unitOfWork.BasketRepository.GetBasketAsync(basketId);
        if (basket == null || basket.Items.Count == 0)
            return BadRequest(new ApiResponse<string>(false, "El carrito está vacío."));

        var order = OrderMapper.FromBasket(basket, userId, address.Id);

        foreach (var item in order.Items)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(item.ProductId);
            if (product != null)
            {
                product.Stock -= item.Quantity;

                if (product.Stock < 0)
                {
                    return BadRequest(
                        new ApiResponse<string>(
                            false,
                            $"No hay suficiente stock para el producto {product.Name}."
                        )
                    );
                }
            }
        }

        await _unitOfWork.OrderRepository.CreateOrderAsync(order);
        _unitOfWork.BasketRepository.DeleteBasket(basket);
        await _unitOfWork.SaveChangeAsync();

        return Ok(
            new ApiResponse<OrderDto>(
                true,
                "Pedido realizado exitosamente.",
                OrderMapper.ToOrderDto(order)
            )
        );
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OrderSummaryDto>>>> GetMyOrders()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized(new ApiResponse<string>(false, "Usuario no autenticado"));
        }

        var orders = await _unitOfWork.OrderRepository.GetOrdersByUserIdAsync(userId);
        List<OrderSummaryDto> mapped = orders.Select(OrderMapper.ToSummaryDto).ToList();

        return Ok(
            new ApiResponse<IEnumerable<OrderSummaryDto>>(
                true,
                "Órdenes obtenidas exitosamente.",
                mapped
            )
        );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OrderDto>>> GetOrderById(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
            return Unauthorized(new ApiResponse<string>(false, "Usuario no autenticado"));

        var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(id, userId);
        if (order == null)
            return NotFound(new ApiResponse<OrderDto>(false, "Pedido no encontrado"));

        return Ok(
            new ApiResponse<OrderDto>(true, "Pedido encontrado", OrderMapper.ToOrderDto(order))
        );
    }
}
