using Akb.Data;
using Akb.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AkbDbContext dbContext;

        public AddressesController(AkbDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<List<Address>> Get()
        {
            return await dbContext.Set<Address>().ToListAsync();
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public async Task<Address> Get(int id)
        {
            var address = await dbContext.Set<Address>()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return address;
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task Post([FromBody] Address address)
        {
            await dbContext.Set<Address>().AddAsync(address);
            await dbContext.SaveChangesAsync();

        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Address address)
        {
            var fromDb = await dbContext.Set<Address>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.Address2 = address.Address2;

            await dbContext.SaveChangesAsync();
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fromDb = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.IsActive = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
