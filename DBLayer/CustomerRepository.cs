using Microsoft.EntityFrameworkCore;
using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentProcessingManager.DBLayer
{
    public class CustomerRepository : ICustomerRepository
    {


        private MyDBContext dbcontext;
        public CustomerRepository(MyDBContext context)
        {
            dbcontext = context;
        }

        public async Task<IEnumerable<Customer>> getCustomer()
        {
            try
            {
                return await dbcontext.Customer.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
