namespace WebApiExample.Domain.Entities.Contacts;

public interface IContact
{
    int Id { get; set; }
    int CustomerId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Alias { get; set; }
    string Email { get; set; }
    string? Phone { get; set; }
}