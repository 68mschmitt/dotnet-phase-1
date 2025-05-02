using MediatR;

namespace CqrsMediatRDemo.Application.Commands.Orders;

public record CreateOrderCommand(string ProductId, int Quantity) : IRequest<Guid>;

