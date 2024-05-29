using WebApiExample.Domain.Entities.Contacts;

namespace WebApiExample.Domain.Services;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(Contact contact);
    Task DeleteByIdAsync(int id);
}