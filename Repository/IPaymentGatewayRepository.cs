using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IPaymentGatewayRepository
    {
        public Task<IEnumerable<PaymentGateway>> GetPaymentGateways();
    }
}

