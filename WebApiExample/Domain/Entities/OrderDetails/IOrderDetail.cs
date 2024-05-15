namespace WebApiExample.Domain.Entities.OrderDetails;

public interface IOrderDetail
{
    int Id { get; set; }
    int OrderId { get; set; }
    int ProductId { get; set; }
    int Quantity { get; set; }
}