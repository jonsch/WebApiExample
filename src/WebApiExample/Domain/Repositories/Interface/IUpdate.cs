namespace WebApiExample.Domain.Repositories;

public interface IUpdate<T> : IDisposable where T : class
{
    Task UpdateAsync(T entity);
}