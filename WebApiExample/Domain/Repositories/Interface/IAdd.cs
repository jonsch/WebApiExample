namespace WebApiExample.Domain.Repositories;

public interface IAdd<T> : IDisposable where T : class
{
    Task AddAsync(T entity);
}