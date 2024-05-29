namespace WebApiExample.Domain.Repositories;

public interface IDeleteById
{
    Task DeleteByIdAsync(int id);
}

public interface IDelete<T> : IDisposable where T : class
{
    Task DeleteAsync(T entity);
}