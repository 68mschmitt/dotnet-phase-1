using CqrsMediatRDemo.Application.Interfaces;
using CqrsMediatRDemo.Domain;

namespace CqrsMediatRDemo.Infrastructure.Persistence.Mock;

public class MockOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];

    public ValueTask<Guid> AddAsync(Order order)
    {
        order.Id = Guid.NewGuid();
        _orders.Add(order);

        return new ValueTask<Guid>(order.Id);
    }

    public ValueTask<IEnumerable<Order>> GetAllAsync()
    {
        return new ValueTask<IEnumerable<Order>>(_orders.AsEnumerable());
    }

    public ValueTask<Order?> GetByIdAsync(Guid id)
    {
        return new ValueTask<Order?>(_orders.FirstOrDefault(o => o.Id == id));
    }
}
