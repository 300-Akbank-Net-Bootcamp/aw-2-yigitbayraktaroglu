using Akb.Data;
using Akb.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EftTransactionsController : ControllerBase
    {

        private readonly AkbDbContext dbContext;

        public EftTransactionsController(AkbDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<EftTransactionsController>
        [HttpGet]
        public async Task<List<EftTransaction>> Get()
        {
            return await dbContext.Set<EftTransaction>().ToListAsync();
        }

        // GET api/<EftTransactionsController>/5
        [HttpGet("{id}")]
        public async Task<EftTransaction> Get(int id)
        {
            var eftTransaction = await dbContext.Set<EftTransaction>()
               .Where(x => x.Id == id).FirstOrDefaultAsync();
            return eftTransaction;
        }

        // POST api/<EftTransactionsController>
        [HttpPost]
        public async Task Post([FromBody] EftTransaction eftTransaction)
        {
            await dbContext.Set<EftTransaction>().AddAsync(eftTransaction);
            dbContext.SaveChanges();
        }

        // PUT api/<EftTransactionsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EftTransaction eftTransaction)
        {
            var fromDb = await dbContext.Set<EftTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.Description = eftTransaction.Description;
            dbContext.SaveChanges();
        }

        // DELETE api/<EftTransactionsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fromDb = await dbContext.Set<EftTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
            fromDb.IsActive = false;
            dbContext.SaveChanges();
        }
    }
}
