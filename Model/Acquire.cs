using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Model
{
    public class Acquire
    {
        [Key]
        [Required]
        public int AcquierID { get; set; }
        public string AVSResultCode { get; set; }
        public string AccountNum { get; set; }
        public string AuthAmt { get; set; }
        public string AuthCode { get; set; }
        public string AuthDate { get; set; }
        public string AuthTime { get; set; }
        public string Brand { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public string ExpDate { get; set; }
        public string GMID { get; set; }
        public string GMPW { get; set; }
        public string GTID { get; set; }
        public string GTRC { get; set; }
        public string MainAmt { get; set; }
        public string Medium { get; set; }
        public string MerchantAddr { get; set; }
        public string MerchantCity { get; set; }
        public string MerchantName { get; set; }
        public string MerchantPhoneNum { get; set; }
        public string MerchantState { get; set; }
        public string MerchantZip { get; set; }
        public string NewRecordCreated { get; set; }
        public string ProcessorID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string ResultCode { get; set; }
        public string ResultText { get; set; }
        public string SESSIONID { get; set; }
        public string Status { get; set; }
        public string TipAmt { get; set; }
        public string TransType { get; set; }
        public string TransactionIdentifier { get; set; }
    }
}
