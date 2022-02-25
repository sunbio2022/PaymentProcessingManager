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
            try
            {
                return await dbcontext.Acquisition.Include(a=>a.AuthorizeStatus).AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<AuthorizeStatus>> GetAuthorizeStatus()
        {
            try
            {
                return await dbcontext.AuthorizeStatus.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
