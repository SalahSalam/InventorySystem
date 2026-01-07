using API.DTO;
using ApplicationsLayer.Commands.ProductCommands;
using ApplicationsLayer.Handlers.ProductHandler;
using ApplicationsLayer.Queries.ProductQuery;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase

{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] GetAllProductsHandler handler)
    {
        var result = await handler.Handle(new GetAllProducts());
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        int id,
        [FromServices] GetProductByIdHandler handler)
    {
        var dto = await handler.Handle(new GetProductById { ProductId = id });
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
    [FromBody] CreateProductCommand cmd,
    [FromServices] CreateProductHandler handler)
    {
        var id = await handler.Handle(cmd);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDetails(
    int id,
    [FromBody] UpdateProductDetailsRequestDto request,
    [FromServices] UpdateProductDetailsHandler handler)
    {
        var cmd = new UpdateProductDetailsCommand(
            id,
            request.Name,
            request.Description,
            request.Category,
            request.Price,
            request.Minimumstock
        );

        await handler.Handle(cmd);
        return NoContent();
    }


    [HttpPatch("{id:int}/minimum-stock")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMinimumStock(
        int id,
        [FromBody] UpdateProductMinimumStockCommand cmd,
        [FromServices] UpdateProductMinimumStockHandler handler)
    {
        cmd.ProductId = id;

        await handler.Handle(cmd);
        return NoContent();
    }

    [HttpGet("below-minimum-stock")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBelowMinimumStock(
        [FromServices] GetProductsBelowMinimumStockHandler handler)
    {
        var result = await handler.Handle();
        return Ok(result);
    }
}
