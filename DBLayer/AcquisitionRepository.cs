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
    public class AcquisitionRepository : IAcquisitionRepository
    {
        private MyDBContext _dbcontext;
        public AcquisitionRepository(MyDBContext context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<Acquisition>> GetAcquisition()
        {
            try
            {
                return await _dbcontext.Acquisition.Where(a => a.Acquisitions != 1).OrderByDescending(a => a.AcquisitionID).AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateAcquisition(int id)
        {
            try
            {
                var acquisition = await _dbcontext.Acquisition.Where(a => a.AcquisitionID == id).AsQueryable().FirstOrDefaultAsync();
                acquisition.Acquisitions = 1;
                _dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateCustomerandAccount(string customer, string account, string acquisitionID)
        {
            try
            {
                int acquisition = Int32.Parse(acquisitionID);
                int customers = Int32.Parse(customer);
                var accounts = Int32.Parse(account);
                if (acquisition > 0 && customers > 0 && accounts > 0)
                {
                    var acquisitions = await _dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisition).AsQueryable().FirstOrDefaultAsync();
                    acquisitions.CustomerID = customers;
                    acquisitions.ServiceRegistryID = accounts;
                }
                _dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateReconsilation(int acquisitionID)
        {
            try
            {
                var acquisition = await _dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisitionID).AsQueryable().FirstOrDefaultAsync();
                acquisition.Reconsilation = 1;
                _dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<int> UpdatePostPayment(int acquisitionID)
        {
            try
            {
                var acquisition = await _dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisitionID).AsQueryable().FirstOrDefaultAsync();
                acquisition.PostPayment = 1;
                _dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
