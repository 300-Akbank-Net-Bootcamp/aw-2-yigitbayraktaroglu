using Akb.Data;
using Akb.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly AkbDbContext dbContext;
        public AccountsController(AkbDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<List<Account>> Get()
        {
            return await dbContext.Set<Account>().ToListAsync();

        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<Account> Get(int id)
        {
            var account = await dbContext.Set<Account>()
                .Include(x => x.EftTransactions)
                .Include(x => x.AccountTransactions)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return account;
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task Post([FromBody] Account account)
        {
            await dbContext.Set<Account>().AddAsync(account);
            await dbContext.SaveChangesAsync();

        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Account account)
        {

            var fromDb = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.Name = account.Name;

            await dbContext.SaveChangesAsync();
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fromDb = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.IsActive = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
