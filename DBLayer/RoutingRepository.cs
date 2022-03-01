using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    [ApiController]
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
                return await dbcontext.Acquisition.Where(a=>a.Routing!=1 && a.Reconsilation ==1).OrderByDescending(a=>a.AcquisitionID).AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            try
            {
                return await dbcontext.Customer.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Acquisition>> GetReconsilation()
        {
            try
            {
                return await dbcontext.Acquisition.Where(a => a.Reconsilation != 1 && a.Acquisitions==1).OrderByDescending(a => a.AcquisitionID).AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
        public async Task<IEnumerable<Department>> GetDepartmentByDescription(string description)
        {
            try
            {
                return await dbcontext.Departments.Where(d => d.Name.Contains(description)).AsQueryable().ToListAsync();

                // return await dbcontext.Departments.AsSingleQuery("select * from Departments where name LIKE %description% ").ToList().AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Acquisition> GetAcquisitionById(int AcquisitionID)
        {
            try
            {
                return await dbcontext.Acquisition.FindAsync(AcquisitionID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateRouting(int acquisitionID)
        {
            try
            {
                var acquisition = await dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisitionID).AsQueryable().FirstOrDefaultAsync();
                acquisition.Routing = 1;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateDep(int department, int acquisitionID)
        {
            try
            {
                var acquisition = await dbcontext.Acquisition.Where(a => a.AcquisitionID == acquisitionID).AsQueryable().FirstOrDefaultAsync();
                acquisition.DepartmentID = department;
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
