namespace WebApiExample.Domain.Repositories;

public interface IRepository<T> : IAdd<T>, IDelete<T>, IUpdate<T>, IDisposable where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteByIdAsync(int id);
    Task AddAsync(T entity);
}