using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductRepository productRepository) : ControllerBase
    {
        private readonly IProductRepository _productRepository = productRepository;

        // GET: api/Product
        // Obtiene todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/Product/5
        // Obtiene un producto por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET: api/Product/price-range?min=100&max=500
        // Filtra productos por rango de precio
        [HttpGet("price-range")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPriceRange(
            [FromQuery] decimal min,
            [FromQuery] decimal max
        )
        {
            if (min > max)
                return BadRequest("El valor mínimo no puede ser mayor que el máximo");

            var products = await _productRepository.GetProductsByPriceRangeAsync(min, max);
            return Ok(products);
        }

        // GET: api/Product/search?term=laptop
        // Busca productos por nombre o descripción
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(
            [FromQuery] string term
        )
        {
            var products = await _productRepository.SearchProductsAsync(term);
            return Ok(products);
        }

        // GET: api/Product/store/1
        // Obtiene productos de una tienda específica
        [HttpGet("store/{storeId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByStore(int storeId)
        {
            var products = await _productRepository.GetProductsByStoreAsync(storeId);
            return Ok(products);
        }

        // GET: api/Product/group-by-store
        // Agrupa productos por tienda y cuenta cuántos hay en cada una
        [HttpGet("group-by-store")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsGroupedByStore()
        {
            var groupedProducts = await _productRepository.GetProductsGroupedByStoreAsync();
            return Ok(groupedProducts);
        }

        // GET: api/Product/expensive
        // Obtiene el producto más caro
        [HttpGet("expensive")]
        public async Task<ActionResult<Product>> GetMostExpensiveProduct()
        {
            var product = await _productRepository.GetMostExpensiveProductAsync();

            if (product == null)
                return NotFound("No se encontraron productos");

            return Ok(product);
        }
    }
}