using Akb.Data;
using Akb.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly AkbDbContext dbContext;

        public CustomersController(AkbDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await dbContext.Set<Customer>().ToListAsync();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<Customer> GetbyId(int id)
        {
            var customer = await dbContext.Set<Customer>()
                .Include(x => x.Accounts)
                .Include(x => x.Addresses)
                .Include(x => x.Contacts)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return customer;

        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await dbContext.Set<Customer>().AddAsync(customer);
            await dbContext.SaveChangesAsync();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Customer customer)
        {
            var fromDb = await dbContext.Set<Customer>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.FirstName = customer.FirstName;
            fromDb.LastName = customer.LastName;

            await dbContext.SaveChangesAsync();

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fromDb = await dbContext.Set<Customer>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.IsActive = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
