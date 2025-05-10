using api.src.Data;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductRepository productRepository, UnitOfWork unitOfWork) : ControllerBase
    {
        private readonly UnitOfWork _context = unitOfWork;
        private readonly IProductRepository _productRepository = productRepository;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
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