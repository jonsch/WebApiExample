using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Domain;
using WebApiExample.Domain.Entities.Orders;
using WebApiExample.Domain.Services;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = Constants.ApiPolicyName)]
public class OrdersController(IOrderService orderService, ILogger<OrderService> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await orderService.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await orderService.GetByIdAsync(id);
        if(order is null)
            return NoContent();
        
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] Order order)
    {
        await orderService.AddAsync(order);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateOrder([FromBody] Order order)
    {
        await orderService.UpdateAsync(order);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        await orderService.DeleteByIdAsync(id);
        return Ok();
    }
}