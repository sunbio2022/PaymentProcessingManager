using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<IEnumerable<ServiceRegistry>> GetServiceRegistry(string merchantId)
        {
            return await dbcontext.ServiceRegistry.Include(p => p.PaymentGateway).Include(d => d.Department).Where(s=>s.MerchantID==merchantId).AsQueryable().ToListAsync();

        }
    }
}
