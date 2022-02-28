using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class Customer
    {

        //[Key]
        //public int id { get; set; }

        
        //public string customer_name { get; set; }
        //public string id_number { get; set; }
        //public string payment_method { get; set; }
        //public string bill_type { get; set; }
        //public double amount { get; set; }
        //public string currency { get; set; }
        //public string transaction_date { get; set; }
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAccount { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }


    }
}
