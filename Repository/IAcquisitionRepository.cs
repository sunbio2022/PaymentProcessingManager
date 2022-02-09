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
    }
}
