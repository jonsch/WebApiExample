using WebApiExample.Domain.Entities.Orders;
using WebApiExample.Domain.Repositories;

namespace WebApiExample.Domain.Services;

public class OrderService(IRepository<Order> orderRepository, ILogger<OrderService> logger) : IOrderService
{

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        try {
            return await orderRepository.GetAllAsync();
        } catch (Exception ex) {
            logger.LogError("Error getting orders: {0}", ex.Message);
            return [];
        }
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        try {
            return await orderRepository.GetByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error getting order by id: {0}", ex.Message);
            return null;
        }
    }

    public async Task AddAsync(Order order)
    {
        try {
            await orderRepository.AddAsync(order);
        } catch (Exception ex) {
            logger.LogError("Error adding order: {0}", ex.Message);
        }
    }

    public async Task UpdateAsync(Order order)
    {
        try { 
            await orderRepository.UpdateAsync(order);
        } catch (Exception ex) {
            logger.LogError("Error updating order: {0}", ex.Message);
        }
    }

    public async Task DeleteAsync(Order order)
    {
        try {
            await orderRepository.DeleteAsync(order);
        } catch (Exception ex) {
            logger.LogError("Error deleting order: {0}", ex.Message);
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        try {
            await orderRepository.DeleteByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error deleting order by id: {0}", ex.Message);
        }
    }
}