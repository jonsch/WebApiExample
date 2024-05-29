using WebApiExample.Domain.Entities.OrderDetails;
using WebApiExample.Domain.Repositories;

namespace WebApiExample.Domain.Services;

public class OrderDetailService(IOrderDetailRepository<OrderDetail> orderDetailRepository, ILogger<OrderDetailService> logger) : IOrderDetailService
{
    public async Task<IEnumerable<OrderDetail>> GetAllAsync()
    {
        try {
            return await orderDetailRepository.GetAllAsync();
        } catch (Exception ex) {
            logger.LogError("Error getting order details: {0}", ex.Message);
            return [];
        }
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        try {
            return await orderDetailRepository.GetByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error getting order detail by id: {0}", ex.Message);
            return null;
        }
    }

    public async Task AddAsync(OrderDetail order)
    {
        try {
            await orderDetailRepository.AddAsync(order);
        } catch (Exception ex) {
            logger.LogError("Error adding order detail: {0}", ex.Message);
        }
    }

    public async Task UpdateAsync(OrderDetail order)
    {
        try { 
            await orderDetailRepository.UpdateAsync(order);
        } catch (Exception ex) {
            logger.LogError("Error updating order detail: {0}", ex.Message);
        }
    }

    public async Task DeleteAsync(OrderDetail order)
    {
        try {
            await orderDetailRepository.DeleteAsync(order);
        } catch (Exception ex) {
            logger.LogError("Error deleting order detail: {0}", ex.Message);
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        try {
            await orderDetailRepository.DeleteByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error deleting order detail by id: {0}", ex.Message);
        }
    }
    
    public async Task<IEnumerable<OrderDetail>> GetAllByOrderId(int id)
    {
        try
        {
            return await orderDetailRepository.GetAllByOrderId(id);
        } catch (Exception ex) {
            logger.LogError("Error getting order details by order id: {0}", ex.Message);
            return [];
        }
    }
}