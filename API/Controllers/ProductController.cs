using ApplicationsLayer.Handlers;              // ✅ Application layer dependency
using ApplicationsLayer.Commands;
using ApplicationsLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll(
        GetAllProductsHandler handler,
        CancellationToken ct)
        {
            var products = await handler.Handle(ct);

            if (!products.Any())
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(
            int id,
            GetProductByIdHandler handler,
            CancellationToken ct)
        {
            var product = await handler.Handle(id, ct);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(
            CreateProductCommand command,
            CreateProductHandler handler,
            CancellationToken ct)
        {
            var product = await handler.Handle(command, ct);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}
