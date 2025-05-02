using CqrsMediatRDemo.Domain;
using MediatR;

namespace CqrsMediatRDemo.Application.Queries.Orders;

public record GetOrderByIdQuery(Guid Guid) : IRequest<Order>;
