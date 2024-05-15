using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiExample.Domain.Entities.OrderDetails;

namespace WebApiExample.Domain.Entities.Orders;

public class Order : IOrder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public string ShipMethod { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipState { get; set; }
    public string ShipZip { get; set; }
    public string? ShipPhone { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}