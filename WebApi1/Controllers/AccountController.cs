using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;


namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountSentences accountSentence;
        public AccountController()
        {
            this.accountSentence = new AccountSentences();
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return this.accountSentence.getAccounts().ToList();
        }

        // GET api/<AccountController>/4543554
        [HttpGet("{id}")]
        public Account Get(string id)
        {
            return this.accountSentence.getAccountBalance(id);
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut]
        public Invoice Put([FromBody] Invoice invoice)
        {
            this.accountSentence.realizarPago(invoice.clientAccount, invoice.amount);
            invoice.status = true;
            return invoice;
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
