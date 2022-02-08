    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class PaymentGateway
    {
        [Key]
        public int PaymentGatewayID { get; set; }
        public string PaymentGatewayName { get; set; }
        public bool IsActive { get; set; }

    }
}
