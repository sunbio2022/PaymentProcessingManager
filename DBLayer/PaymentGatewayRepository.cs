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
    public class PaymentGatewayRepository: IPaymentGatewayRepository
    {
        private MyDBContext _dbcontext;
        public PaymentGatewayRepository(MyDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<PaymentGateway>> GetPaymentGateways()
        {
            return await _dbcontext.PaymentGateways.AsQueryable().ToListAsync();
        }
    }
}
