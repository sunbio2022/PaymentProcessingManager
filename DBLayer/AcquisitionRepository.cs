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
    public class AcquisitionRepository:IAcquisitionRepository
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
                return await _dbcontext.Acquisition.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
