using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApiExample.Domain;
using WebApiExample.Domain.Entities.Contacts;
using WebApiExample.Domain.Services;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = Constants.ApiPolicyName)]
public class ContactsController(IContactService contactService, ILogger<ContactsController> logger) : ControllerBase
{
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
    {
        var contacts = await contactService.GetAllAsync();
        return Ok(contacts);
    }

    [HttpGet]
    [Route("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Contact>> GetContact(int id)
    {
        var contact = await contactService.GetByIdAsync(id);
        if(contact is null)
            return NoContent();
        
        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult> AddContact([FromBody] Contact contact)
    {
        await contactService.AddAsync(contact);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateContact([FromBody] Contact contact)
    {
        await contactService.UpdateAsync(contact);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteContact(int id)
    {
        await contactService.DeleteByIdAsync(id);
        return Ok();
    }
}