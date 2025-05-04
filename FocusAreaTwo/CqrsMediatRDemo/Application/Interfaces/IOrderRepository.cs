using CqrsMediatRDemo.Domain;

namespace CqrsMediatRDemo.Application.Interfaces;

public interface IOrderRepository
{
    ValueTask<Order?> GetByIdAsync(Guid id);

    ValueTask<IEnumerable<Order>> GetAllAsync();

    ValueTask<Guid> AddAsync(Order order);
}
