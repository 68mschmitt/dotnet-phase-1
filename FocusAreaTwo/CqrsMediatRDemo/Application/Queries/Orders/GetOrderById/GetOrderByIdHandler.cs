using CqrsMediatRDemo.Application.Interfaces;
using CqrsMediatRDemo.Domain;
using MediatR;

namespace CqrsMediatRDemo.Application.Queries.Orders.GetOrderById;

public class GetOrderByIdHandler(IOrderRepository repo) : IRequestHandler<GetOrderByIdQuery, Order?>
{
    private readonly IOrderRepository _repo = repo;

    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (request?.Guid is null)
            throw new ArgumentNullException(nameof(request));

        return await _repo.GetByIdAsync(request.Guid); 
    }
}
