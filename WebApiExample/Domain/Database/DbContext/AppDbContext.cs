using Microsoft.EntityFrameworkCore;
using WebApiExample.Domain.Entities.Contacts;
using WebApiExample.Domain.Entities.Customers;
using WebApiExample.Domain.Entities.OrderDetails;
using WebApiExample.Domain.Entities.Orders;
using WebApiExample.Domain.Entities.Products;

namespace WebApiExample.Domain.Database.DbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}
