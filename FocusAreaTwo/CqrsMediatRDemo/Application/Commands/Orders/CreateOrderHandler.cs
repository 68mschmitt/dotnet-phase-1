using CqrsMediatRDemo.Application.Interfaces;
using CqrsMediatRDemo.Domain;
using MediatR;

namespace CqrsMediatRDemo.Application.Commands.Orders;

public class CreateOrderHandler(IOrderRepository repo) : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _repo = repo;

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order { ProductId = request.ProductId, Quantity = request.Quantity };
        return await _repo.AddAsync(order);
    }
}
