using ApplicationsLayer.Commands.OrderCommands;
using ApplicationsLayer.DTO;
using ApplicationsLayer.Handlers.OrderHandler;
using ApplicationsLayer.Queries.OrderQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    // ----------------------------------
    // GET: api/orders
    // ----------------------------------
    [HttpGet]
    [ProducesResponseType(typeof(List<OrderDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<OrderDTO>>> GetAll(
        [FromServices] GetAllOrdersHandler handler,
        CancellationToken ct)
    {
        var query = new GetAllOrders();
        var orders = await handler.Handle(query);

        if (orders.Count == 0)
            return NotFound();

        return Ok(orders);
    }

    // ----------------------------------
    // GET: api/orders/open
    // ----------------------------------
    [HttpGet("open")]
    [ProducesResponseType(typeof(List<OrderDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<OrderDTO>>> GetOpenOrders(
        [FromServices] GetOpenOrdersHandler handler,
        CancellationToken ct)
    {
        var query = new GetOpenOrders();
        var orders = await handler.Handle(query);

        if (orders.Count == 0)
            return NotFound();

        return Ok(orders);
    }

    // ----------------------------------
    // GET: api/orders/{id}
    // ----------------------------------
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderDTO>> GetById(
        int id,
        [FromServices] GetOrderByIdHandler handler,
        CancellationToken ct)
    {
        var query = new GetOrderById { OrderId = id };
        var order = await handler.Handle(query);

        if (order is null)
            return NotFound();

        return Ok(order);
    }

    // ----------------------------------
    // POST: api/orders
    // ----------------------------------
    [HttpPost]
    [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status201Created)]
    public async Task<ActionResult<OrderDTO>> CreateOrder(
        [FromBody] CreateOrder command,
        [FromServices] CreateOrderHandler createHandler,
        [FromServices] GetOrderByIdHandler getByIdHandler,
        CancellationToken ct)
    {
        var createdOrderId = await createHandler.Handle(command);

        var order = await getByIdHandler.Handle(
            new GetOrderById { OrderId = createdOrderId });

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdOrderId },
            order
        );
    }

    // ----------------------------------
    // POST: api/orders/{id}/close
    // ----------------------------------
    [HttpPost("{id:int}/close")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CloseOrder(
        int id,
        [FromServices] CloseOrderHandler handler,
        CancellationToken ct)
    {
        var command = new CloseOrder { OrderId = id };
        await handler.Handle(command);

        return NoContent();
    }
}
