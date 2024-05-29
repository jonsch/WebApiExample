using WebApiExample.Domain.Entities.OrderDetails;

namespace WebApiExample.Domain.Entities.Orders;

public interface IOrder
{
    int Id { get; set; }
    int CustomerId { get; set; }
    DateTime OrderDate { get; set; }
    DateTime? ShipDate { get; set; }
    string ShipMethod { get; set; }
    string ShipAddress { get; set; }
    string ShipCity { get; set; }
    string ShipState { get; set; }
    string ShipZip { get; set; }
    string? ShipPhone { get; set; }
    ICollection<OrderDetail> OrderDetails { get; set; }
}