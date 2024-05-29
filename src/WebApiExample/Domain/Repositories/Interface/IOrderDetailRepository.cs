namespace WebApiExample.Domain.Repositories;

public interface IOrderDetailRepository<T> : IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllByOrderId(int id);
}