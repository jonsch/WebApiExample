using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Domain;
using WebApiExample.Domain.Entities.OrderDetails;
using WebApiExample.Domain.Services;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = Constants.ApiPolicyName)]
public class OrderDetailsController(IOrderDetailService orderDetailService, ILogger<OrderDetailsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
    {
        var orderDetails = await orderDetailService.GetAllAsync();
        return Ok(orderDetails);
    }
    
    [HttpGet]
    [Route("{orderId:int}")]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsByOrderId(int orderId)
    {
        var orderDetails = await orderDetailService.GetAllByOrderId(orderId);
        return Ok(orderDetails);
    }
}