using CqrsMediatRDemo.Domain;
using MediatR;

namespace CqrsMediatRDemo.Application.Queries.Orders.GetOrderById;

public record GetOrderByIdQuery(Guid Guid) : IRequest<Order>;
