using Akb.Data;
using Akb.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransactionsController : ControllerBase
    {
        private readonly AkbDbContext dbContext;

        public AccountTransactionsController(AkbDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<AccountTransactionsController>
        [HttpGet]
        public async Task<List<AccountTransaction>> Get()
        {
            return await dbContext.Set<AccountTransaction>().ToListAsync();
        }

        // GET api/<AccountTransactionsController>/5
        [HttpGet("{id}")]
        public async Task<AccountTransaction> Get(int id)
        {
            var accountTransaction = await dbContext.Set<AccountTransaction>()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return accountTransaction;
        }

        // POST api/<AccountTransactionsController>
        [HttpPost]
        public async Task Post([FromBody] AccountTransaction accountTransaction)
        {
            await dbContext.Set<AccountTransaction>().AddAsync(accountTransaction);
            dbContext.SaveChanges();
        }

        // PUT api/<AccountTransactionsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AccountTransaction accountTransaction)
        {
            var fromDb = await dbContext.Set<AccountTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.Description = accountTransaction.Description;
            dbContext.SaveChanges();
        }

        // DELETE api/<AccountTransactionsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fromDb = await dbContext.Set<AccountTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.IsActive = false;
            dbContext.SaveChanges();
        }
    }
}
