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
        public int AcquisitionID { get; set; }
        public int TransactionID { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public decimal Currency { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public int? AuthorizeStatusID { get; set; }
        public virtual AuthorizeStatus AuthorizeStatus { get; set; }
        public int? PostData { get; set; }
        public string BURS { get; set; }
        public string BURSNotes { get; set; }
        
    }
}
