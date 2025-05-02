using CqrsMediatRDemo.Application.Interfaces;
using CqrsMediatRDemo.Domain;
using MediatR;

namespace CqrsMediatRDemo.Application.Queries.Orders.GetAllOrders;

public class GetAllOrdersHandler(IOrderRepository repo) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _repo = repo;

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repo.GetAllAsync();
        return orders.AsEnumerable();
    }
}
