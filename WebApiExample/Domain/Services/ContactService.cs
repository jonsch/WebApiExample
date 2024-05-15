using WebApiExample.Domain.Entities.Contacts;
using WebApiExample.Domain.Repositories;

namespace WebApiExample.Domain.Services;

public class ContactService(IRepository<Contact> contactRepository, ILogger<ContactService> logger) : IContactService
{
    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        try {
            return await contactRepository.GetAllAsync();
        } catch (Exception ex) {
            logger.LogError("Error getting contacts: {0}", ex.Message);
            return [];
        }
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        try {
            return await contactRepository.GetByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error getting contact by id: {0}", ex.Message);
            return null;
        }
    }

    public async Task AddAsync(Contact contact)
    {
        try {
            await contactRepository.AddAsync(contact);
        } catch (Exception ex) {
            logger.LogError("Error adding contact: {0}", ex.Message);
        }
    }

    public async Task UpdateAsync(Contact contact)
    {
        try { 
            await contactRepository.UpdateAsync(contact);
        } catch (Exception ex) {
            logger.LogError("Error updating contact: {0}", ex.Message);
        }
    }
    
    public async Task DeleteAsync(Contact contact)
    {
        try {
            await contactRepository.DeleteAsync(contact);
        } catch (Exception ex) {
            logger.LogError("Error deleting contact: {0}", ex.Message);
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        try { 
            await contactRepository.DeleteByIdAsync(id);
        } catch (Exception ex) {
            logger.LogError("Error deleting contact by id: {0}", ex.Message);
        }
    }
}