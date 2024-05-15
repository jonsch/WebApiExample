using WebApiExample.Domain.Entities.Customers;
using WebApiExample.Domain.Repositories;

namespace WebApiExample.Domain.Services;

public class CustomerService(IRepository<Customer> customerRepository, ILogger<CustomerService> logger) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        try {
            return await customerRepository.GetAllAsync();
        } catch (Exception ex) {
            logger.LogError("Error getting customers: {0}", ex.Message);
            return [];
        }
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        try {
            return await customerRepository.GetByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error getting customer by id: {0}", ex.Message);
            return null;
        }
    }

    public async Task AddAsync(Customer customer)
    {
        try {
            await customerRepository.AddAsync(customer);
        } catch (Exception ex) {
            logger.LogError("Error adding customer: {0}", ex.Message);
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        try {
            await customerRepository.DeleteByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error deleting customer: {0}", ex.Message);
        }
    }

    public async Task UpdateAsync(Customer customer)
    {
        try {
            await customerRepository.UpdateAsync(customer);
        } catch (Exception ex) {
            logger.LogError("Error updating customer: {0}", ex.Message);
        }
    }
    
    public async Task DeleteAsync(Customer customer)
    {
        try {
            await customerRepository.DeleteAsync(customer);
        } catch (Exception ex) {
            logger.LogError("Error deleting customer: {0}", ex.Message);
        }
    }
    
    public async Task DeleteCustomerByIdAsync(int id)
    {
        try {
            await customerRepository.DeleteByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error deleting customer by id: {0}", ex.Message);
        }
    }
}