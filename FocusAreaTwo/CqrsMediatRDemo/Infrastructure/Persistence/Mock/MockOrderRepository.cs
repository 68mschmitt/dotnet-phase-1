using CqrsMediatRDemo.Application.Interfaces;
using CqrsMediatRDemo.Domain;

namespace CqrsMediatRDemo.Infrastructure.Persistence.Mock;

public class MockOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];

    public Task<Guid> AddAsync(Order order)
    {
        order.Id = Guid.NewGuid();
        _orders.Add(order);
        return Task.FromResult(order.Id);
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        return Task.FromResult(_orders.AsEnumerable());
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
    }
}
