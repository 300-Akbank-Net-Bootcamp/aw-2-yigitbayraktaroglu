using Akb.Data;
using Akb.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AkbDbContext dbContext;
        public ContactsController()
        {
            this.dbContext = dbContext;
        }
        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<List<Contact>> Get()
        {
            return await dbContext.Set<Contact>().ToListAsync();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            var contact = await dbContext.Set<Contact>()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return contact;
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task Post([FromBody] Contact contact)
        {
            await dbContext.Set<Contact>().AddAsync(contact);
            dbContext.SaveChanges();
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Contact contact)
        {
            var fromDb = await dbContext.Set<Contact>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.Information = contact.Information;
            await dbContext.SaveChangesAsync();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fromDb = await dbContext.Set<Contact>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.IsActive = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
