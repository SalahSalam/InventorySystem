using ApplicationsLayer.Interfaces;              // ✅ Application layer dependency
using InventorySystem.Domain.Entities;            // ⚠ Domain entity (explained below)
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // ✅ Dependency inversion: controller depends on an interface from Application layer
        private readonly IGenericRepository<Product> _repository;

        // ✅ Constructor injection via interface (IoC)
        public ProductsController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        // -------------------------
        // GET: api/products
        // -------------------------
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            // ✅ Async call to repository
            var products = await _repository.GetAllAsync();

            // ✅ Proper null / empty check
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // -------------------------
        // GET: api/products/{id}
        // -------------------------
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            // ✅ Repository handles data access, controller only handles HTTP
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // -------------------------
        // POST: api/products
        // -------------------------
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            // ✅ Model validation handled by [ApiController]
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // ✅ Await async call
                await _repository.AddAsync(product);

                // ✅ Correct RESTful Created response
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = product.ProductId },
                    product
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // ✅ Domain validation errors translated to HTTP 400
                return BadRequest(ex.Message);
            }
        }
    }
}
