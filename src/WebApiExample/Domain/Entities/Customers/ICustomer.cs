using WebApiExample.Domain.Entities.Contacts;

namespace WebApiExample.Domain.Entities.Customers;

public interface ICustomer
{
    int Id { get; set; }
    string Name { get; set; }
    string AddressLine1 { get; set; }
    string? AddressLine2 { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zip { get; set; }
    string EmailAddress { get; set; }
    string? Phone { get; set; }
    ICollection<Contact> Contacts { get; set; }
}