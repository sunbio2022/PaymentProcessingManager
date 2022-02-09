using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string TransactionID { get; set; }
    }
       
    }
