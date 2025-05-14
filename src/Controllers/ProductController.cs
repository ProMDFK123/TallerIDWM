using Microsoft.AspNetCore.Mvc;
using TallerIDWM.Src.Data;
using TallerIDWM.Src.Helpers;
using TallerIDWM.Src.Interfaces;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Controllers
{
    public class ProductController(IProductRepository productRepository, UnitOfWork unitOfWork)
        : BaseController
    {
        private readonly UnitOfWork _context = unitOfWork;
        private readonly IProductRepository _productRepository = productRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(
                new ApiResponse<IEnumerable<Product>>(
                    true,
                    "Productos obtenidos correctamente",
                    products
                )
            );
        }

        // GET: api/Product/5
        // Obtiene un producto por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
