using CqrsMediatRDemo.Domain;

namespace CqrsMediatRDemo.Application.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);

    Task<IEnumerable<Order>> GetAllAsync();

    Task<Guid> AddAsync(Order order);
}
