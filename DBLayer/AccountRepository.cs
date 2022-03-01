using Microsoft.EntityFrameworkCore;
using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.DBLayer
{
    public class AccountRepository: IAccountRepository
    {
        private MyDBContext dbcontext;
        public AccountRepository(MyDBContext context)
        {
            dbcontext = context;
        }

        public async Task<IEnumerable<ServiceRegistry>> GetServiceRegistry()
        {
            return await dbcontext.ServiceRegistry.AsQueryable().ToListAsync();

        }
        public async Task<IEnumerable<Acquisition>> GetServiceRegistryByMerchantID(int serviceregistryID)
        {
            return await dbcontext.Acquisition.Where(a=>a.PostPayment == 1 && a.ServiceRegistryID == serviceregistryID).AsQueryable().ToListAsync();

        }
    }
}
