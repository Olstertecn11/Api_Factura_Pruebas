using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;


namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountSentences accountSentence;
        public InvoiceSentence invSentence;
        public AccountController()
        {
            this.accountSentence = new AccountSentences();
            this.invSentence = new InvoiceSentence();
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
            return this.accountSentence.getAccountByNit(id);
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut]
        public Response<Invoice> Put([FromBody] Invoice invoice)
        {
            if (this.accountSentence.checkPaymentViability(invoice.clientNit, invoice.amount))
            {
                this.accountSentence.makeServicePayment(invoice.clientNit, invoice.amount);
                invoice.status = true;
                this.invSentence.changeInvoiceStatus(invoice.id);
                return new Response<Invoice>(300, "Pago realizado correctamente", invoice);
            }
            return new Response<Invoice>(402, "Fondos insuficientes para realizar el pago", invoice);

        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
