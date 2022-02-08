using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class Acquisition
    {
        [Key]
        [Required]
        public int Transaction_ID { get; set; }
        public string Payment_Method { get; set; }
        public decimal Amount { get; set; }
        public decimal Currency { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Description { get; set; }
    }
}
