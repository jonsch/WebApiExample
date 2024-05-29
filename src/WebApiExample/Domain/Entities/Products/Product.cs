using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiExample.Domain.Entities.Products;

public class Product : IProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public string? Category { get; set; }
    public string? SubCategory { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public bool IsActive { get; set; }
    public bool IsOnSale { get; set; }
}