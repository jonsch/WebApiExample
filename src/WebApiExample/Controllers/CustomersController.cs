using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Domain;
using WebApiExample.Domain.Entities.Customers;
using WebApiExample.Domain.Services;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = Constants.ApiPolicyName)]
public class CustomersController(ICustomerService customerService, ILogger<CustomersController> logger) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        var customers = await customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await customerService.GetByIdAsync(id);
        
        if (customer is null)
            return NoContent();
        
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromBody] Customer customer)
    {
        await customerService.AddAsync(customer);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCustomer([FromBody] Customer customer)
    {
        await customerService.UpdateAsync(customer);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await customerService.DeleteByIdAsync(id);
        return Ok();
    }
}