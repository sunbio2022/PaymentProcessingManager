using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class ServiceRegistry
    {
        [Key]
        public int ServiceRegistryID { get; set; }
        public int? PaymentGatewayID { get; set; }
        public virtual PaymentGateway PaymentGateway { get; set; }
        public int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public string MerchantID { get; set; }
        public string FolderPath { get; set; }
    }
}
