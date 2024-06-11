using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApiExample.Domain;
using WebApiExample.Domain.Entities.Products;
using WebApiExample.Domain.Services;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = Constants.ApiPolicyName)]
public class ProductsController(IProductService productService, ILogger<ProductsController> logger) : ControllerBase
{
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await productService.GetByIdAsync(id);
        if(product is null)
            return NoContent();
        
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] Product product)
    {
        await productService.AddAsync(product);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
        await productService.UpdateAsync(product);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await productService.DeleteByIdAsync(id);
        return Ok();
    }
}