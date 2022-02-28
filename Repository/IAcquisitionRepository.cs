using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
   public interface IAcquisitionRepository
    {
        public Task<IEnumerable<Acquisition>> GetAcquisition();
        public Task<int> UpdateAcquisition(int id);
        public Task<int> UpdateCustomerandAccount(string customer, string account, string acquisitionID);
        public Task<int> UpdateReconsilation(int acquisitionID);
        public Task<int> UpdatePostPayment(int acquisitionID);
    }
}
