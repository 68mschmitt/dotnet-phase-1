using CqrsMediatRDemo.Application.Commands.Orders.CreateOrder;
using CqrsMediatRDemo.Application.Queries.Orders.GetAllOrders;
using CqrsMediatRDemo.Application.Queries.Orders.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatRDemo.API.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _mediator.Send(command);
        return CreatedAtAction("GetById", new { id = orderId }, new { Id = orderId });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrdersAsync()
    {
        var result = await _mediator.Send(new GetAllOrdersQuery());
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }
}
