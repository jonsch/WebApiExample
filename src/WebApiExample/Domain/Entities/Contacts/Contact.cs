using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiExample.Domain.Entities.Customers;

namespace WebApiExample.Domain.Entities.Contacts;

public class Contact : IContact
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Alias { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string? Phone { get; set; }
    public virtual Customer Customer { get; set; }
}