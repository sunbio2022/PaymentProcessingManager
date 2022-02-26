using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.ViewModel
{
    public class ServiceRegistryModel
    {
        public int DepartmentID{ get; set; }
        public int PaymentGatewayID { get; set; }
        public string MerchantID { get; set; }
        public string FolderPath { get; set; }
    }
}
