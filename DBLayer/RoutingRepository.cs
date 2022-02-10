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
    public class RoutingRepository : IRoutingRepository
    {
        private MyDBContext dbcontext;
        public RoutingRepository(MyDBContext context)
        {
            dbcontext = context;
        }
        public async Task<IEnumerable<Acquisition>> GetRouting()
        {
            try
            {
                return await dbcontext.Acquisition.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<IEnumerable<Department>> GetDepartment()
        {
            try
            {
                return await dbcontext.Departments.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
