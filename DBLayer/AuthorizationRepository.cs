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

        public async Task<IEnumerable<Acquisition>> GetAuthorizations()
        {
            try
            {
                return await dbcontext.Acquisition.Where(a=>a.Routing==1 && a.Authorization !=1).AsQueryable().ToListAsync();
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

        public async Task<IEnumerable<Acquisition>> GetPostPayment()
        {
            return await dbcontext.Acquisition.Where(a => a.Authorization == 1 && a.PostPayment != 1).OrderByDescending(a => a.AcquisitionID).AsQueryable().ToListAsync();
        }

        public async Task<int> UpdateAuthorization(int acquisitionID)
        {
            try
            {
                var acquisition = await dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisitionID).AsQueryable().FirstOrDefaultAsync();
                acquisition.Authorization = 1;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateAuthorizationStatus(int authorizationStatus,  int acquisitionID)
        {
            try
            {
                var acquisition = await dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisitionID).AsQueryable().FirstOrDefaultAsync();
                acquisition.AuthorizeStatusID = authorizationStatus;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
