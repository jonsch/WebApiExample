using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiExample.Domain.Entities.Contacts;

namespace WebApiExample.Domain.Entities.Customers;

public class Customer : ICustomer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    [Phone]
    public string? Phone { get; set; }
    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}