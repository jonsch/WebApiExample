using WebApiExample.Domain.Entities.OrderDetails;

namespace WebApiExample.Domain.Services;

public interface IOrderDetailService
{
    Task<IEnumerable<OrderDetail>> GetAllAsync();
    Task<OrderDetail?> GetByIdAsync(int id);
    Task AddAsync(OrderDetail order);
    Task UpdateAsync(OrderDetail order);
    Task DeleteAsync(OrderDetail order);
    Task DeleteByIdAsync(int id);
}