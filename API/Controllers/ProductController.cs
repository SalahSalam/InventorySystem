using ApplicationsLayer.Commands.ProductCommands;
using ApplicationsLayer.DTO;
using ApplicationsLayer.Handlers.ProductHandler;
using ApplicationsLayer.Queries.ProductQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // -------------------------
    // GET: api/products
    // -------------------------
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ProductDTO>>> GetAll(
         GetAllProductsHandler handler,
         CancellationToken ct)
    {
        var query = new GetAllProducts(); // Create the required query object
        var products = await handler.Handle(query);

        if (products.Count == 0)
            return NotFound();

        return Ok(products);
    }

    // -------------------------
    // GET: api/products/{id}
    // -------------------------
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDTO>> GetById(
      int id,
      GetProductByIdHandler handler,
      CancellationToken ct)
    {
        var query = new GetProductById { ProductId = id };
        var product = await handler.Handle(query);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    // -------------------------
    // POST: api/products
    // -------------------------
    [HttpPost]
    [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDTO>> Create(
    [FromBody] CreateProductCommand command,
    CreateProductHandler handler,
    GetProductByIdHandler getByIdHandler,
    CancellationToken ct)
    {
        // Only check for Name, unless you add Sku to the command
        if (string.IsNullOrWhiteSpace(command.Name))
            return BadRequest("Name is required.");

        try
        {
            // Call without ct, since handler.Handle does not accept it
            var createdId = await handler.Handle(command);

            var productDto = await getByIdHandler.Handle(new GetProductById { ProductId = createdId });

            if (productDto == null)
                return NotFound();

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdId },
                productDto
            );
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
}