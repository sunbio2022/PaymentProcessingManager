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
                return await dbcontext.Acquisition.AsQueryable().ToListAsync();
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

        [HttpGet]
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

        //Task<string> IRoutingRepository.GetDepartmentByDescription(string Description)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
