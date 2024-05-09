using System.ComponentModel;

namespace WebApi1.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public int idService { get; set; }
        public string serviceName { get; set; }
        public string clientNit { get; set; }
        public double amount { get; set; }
        public bool status { get; set; }

        public Invoice(int id, int idService, string serviceName, string clientNit, double amount)
        {
            this.id = id;
            this.idService = idService;
            this.serviceName = serviceName;
            this.clientNit = clientNit;
            this.amount = amount;
            this.status = false;
        }
    }
}
