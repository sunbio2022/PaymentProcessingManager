using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class AuthorizeStatus
    {
        [Key]
        [Required]
        public int AuthorizeStatusID { get; set; }
        public string AuthorizeStatusName { get; set; }
        public bool IsActive { get; set; }
    }
}
