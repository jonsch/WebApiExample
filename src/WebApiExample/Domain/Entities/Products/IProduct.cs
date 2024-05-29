namespace WebApiExample.Domain.Entities.Products;

public interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    string? Description { get; set; }
    decimal Price { get; set; }
    int Quantity { get; set; }
    string? ImageUrl { get; set; }
    string? Category { get; set; }
    string? SubCategory { get; set; }
    string? Manufacturer { get; set; }
    string? Model { get; set; }
    bool IsActive { get; set; }
    bool IsOnSale { get; set; }
}