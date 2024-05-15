using WebApiExample.Domain.Entities.Customers;

namespace WebApiExample.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
    Task DeleteByIdAsync(int id);
    Task DeleteAsync(Customer customer);
    Task UpdateAsync(Customer customer);
}