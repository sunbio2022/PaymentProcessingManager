using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.ViewModel
{
    public class Customers
    {
        public string TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public string Department { get; set; }
        public string SalesAccount { get; set; }
        public string BankAcount { get; set; }
        public double Dr_amount { get; set; }
        public string Cr_amount { get; set; }
    }
}
