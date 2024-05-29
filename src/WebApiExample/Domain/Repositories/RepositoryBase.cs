using Microsoft.EntityFrameworkCore;
using WebApiExample.Domain.Database.DbContext;

namespace WebApiExample.Domain.Repositories;

public class RepositoryBase<T>(AppDbContext dbContext) : IRepository<T>, IAsyncDisposable
    where T : class
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await dbContext.DisposeAsync();
    }
}