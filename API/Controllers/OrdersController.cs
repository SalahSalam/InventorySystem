using API.DTO;
using ApplicationsLayer.Commands.OrderCommands;
using ApplicationsLayer.Handlers.OrderHandler;
using ApplicationsLayer.Queries.OrderQuery;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] GetAllOrdersHandler handler)
    {
        var result = await handler.Handle(new GetAllOrders());
        return Ok(result);
    }

    [HttpGet("{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        int orderId,
        [FromServices] GetOrderByIdHandler handler)
    {
        var dto = await handler.Handle(new GetOrderById { OrderId = orderId });
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpGet("open")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOpen([FromServices] GetOpenOrdersHandler handler)
    {
        var result = await handler.Handle(new GetOpenOrders());
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(
    [FromBody] CreateOrderRequestDto request,
    [FromServices] CreateOrderHandler handler)
    {
        if (request.Lines == null || request.Lines.Count == 0)
            return BadRequest("Order must contain at least one line.");

        var command = new CreateOrder(
            request.Lines.Select(l => new CreateOrderLine(l.ProductId, l.Quantity))
        );

        var id = await handler.Handle(command);
        return CreatedAtAction(nameof(GetById), new { orderId = id }, new { orderId = id });
    }

    [HttpPost("{orderId:int}/close")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Close(
        int orderId,
        [FromServices] CloseOrderHandler handler)
    {
        await handler.Handle(new CloseOrder { OrderId = orderId });
        return NoContent();
    }
}
