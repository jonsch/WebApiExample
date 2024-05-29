using WebApiExample.Domain.Entities.Products;
using WebApiExample.Domain.Repositories;

namespace WebApiExample.Domain.Services;

public class ProductService(IRepository<Product> productRepository, ILogger<ProductService> logger) : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        try {
            return await productRepository.GetAllAsync();
        } catch (Exception ex) {
            logger.LogError("Error getting products: {0}", ex.Message);
            return [];
        }
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        try {
            return await productRepository.GetByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error getting product by id: {0}", ex.Message);
            return null;
        }
    }

    public async Task AddAsync(Product product)
    {
        try {
            await productRepository.AddAsync(product);
        } catch (Exception ex) {
            logger.LogError("Error adding product: {0}", ex.Message);
        }
    }

    public async Task UpdateAsync(Product product)
    {
        try { 
            await productRepository.UpdateAsync(product);
        } catch (Exception ex) {
            logger.LogError("Error updating product: {0}", ex.Message);
        }
    }

    public async Task DeleteAsync(Product product)
    {
        try {
            await productRepository.DeleteAsync(product);
        } catch (Exception ex) {
            logger.LogError("Error deleting product: {0}", ex.Message);
        }
    }
    
    public async Task DeleteByIdAsync(int id)
    {
        try {
            await productRepository.DeleteByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error deleting product by id: {0}", ex.Message);
        }
    }
}