using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IAccountRepository
    {

        public Task<IEnumerable<ServiceRegistry>> GetServiceRegistry();
        public Task<IEnumerable<Acquisition>> GetServiceRegistryByMerchantID(int serviceregistryID);
    }
}
