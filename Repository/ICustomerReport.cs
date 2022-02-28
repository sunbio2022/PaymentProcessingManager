using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface ICustomerRepository
    {

        public Task<IEnumerable<Customer>> getCustomer();
        public Task<IEnumerable<Customer>> GetCustomer();
        public Task<IEnumerable<Acquisition>> getCustomerReport(int customerID);

    }
}
