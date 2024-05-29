using WebApiExample.Domain.Entities.Products;

namespace WebApiExample.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    Task DeleteByIdAsync(int id);
}