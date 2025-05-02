using MediatR;

namespace CqrsMediatRDemo.Application.Commands.Orders.CreateOrder;

public record CreateOrderCommand(string ProductId, int Quantity) : IRequest<Guid>;

