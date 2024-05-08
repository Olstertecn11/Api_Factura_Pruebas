using System.ComponentModel;

namespace WebApi1.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public int idService { get; set; }
        public string serviceName { get; set; }
        public string clientAccount { get; set; }
        public double amount { get; set; }
        public bool status { get; set; }

        public Invoice(int id, int idService, string serviceName, string clientAccount, double amount)
        {
            this.id = id;
            this.idService = idService;
            this.serviceName = serviceName;
            this.clientAccount = clientAccount;
            this.amount = amount;
            this.status = false;
        }
    }
}
