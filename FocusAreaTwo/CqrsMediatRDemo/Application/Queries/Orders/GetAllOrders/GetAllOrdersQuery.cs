using CqrsMediatRDemo.Domain;
using MediatR;

namespace CqrsMediatRDemo.Application.Queries.Orders.GetAllOrders;

public record GetAllOrdersQuery : IRequest<IEnumerable<Order>>;
