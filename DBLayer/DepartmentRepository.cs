using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.DBLayer
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private MyDBContext _dbcontext;
        public DepartmentRepository(MyDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dbcontext.Departments.AsQueryable().ToListAsync(); 
        }
    }
}
