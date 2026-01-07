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
        [FromBody] CreateOrder cmd,
        [FromServices] CreateOrderHandler handler)
    {
        Console.WriteLine("HIT: OrdersController.Create");

        // Handler validerer lines + product existence :contentReference[oaicite:34]{index=34}
        var newId = await handler.Handle(cmd);
        return CreatedAtAction(nameof(GetById), new { orderId = newId }, new { orderId = newId });
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
