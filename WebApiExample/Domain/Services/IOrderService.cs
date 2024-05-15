using WebApiExample.Domain.Entities.Orders;

namespace WebApiExample.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Order order);
    Task DeleteByIdAsync(int id);
}