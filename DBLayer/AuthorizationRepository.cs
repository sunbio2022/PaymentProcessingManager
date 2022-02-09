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
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private MyDBContext dbcontext;
        public AuthorizationRepository(MyDBContext context)
        {
            dbcontext = context;
        }

        public async Task<IEnumerable<Acquisition>> GetAcquisitions()
        {
            return await dbcontext.Acquisition.AsQueryable().ToListAsync();
        }
    }
}
