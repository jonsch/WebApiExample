using Microsoft.EntityFrameworkCore;
using WebApiExample.Domain.Database.DbContext;
using WebApiExample.Domain.Entities.OrderDetails;

namespace WebApiExample.Domain.Repositories;

public class OrderDetailRepository(AppDbContext dbContext) : RepositoryBase<OrderDetail>(dbContext), IOrderDetailRepository<OrderDetail>
{
    private readonly DbSet<OrderDetail> _dbSet = dbContext.OrderDetails;
    
    public async Task<IEnumerable<OrderDetail>> GetAllByOrderId(int id)
    {
        return await _dbSet.Where(od => od.OrderId == id).ToListAsync();
    }
}