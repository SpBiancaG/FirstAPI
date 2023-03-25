using FirstAPI.Data;
using FirstAPI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        
        
        //[] face adnotare
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task< IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Adress = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

           await  dbContext.Contacts.AddAsync(contact);
           await dbContext.SaveChangesAsync();

           
           return Ok(contact);   
        }


        
    }
}
