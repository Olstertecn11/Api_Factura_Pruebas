using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;
using CapaModelo_SisB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public InvoiceSentence invSentence;
        public InvoiceController()
        {
            this.invSentence = new InvoiceSentence();
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public Response<Invoice> Post([FromBody] Invoice invoice)
        {
            Invoice _invoice = this.invSentence.createInvoice(invoice);
            if (_invoice != null) return new Response<Invoice>(200, "Factura Creada", _invoice);
            return new Response<Invoice>(406, "Error al crear la factura", new Invoice(0, 0, "", "", 0));
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
