using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IRoutingRepository
    {
        public Task<IEnumerable<Customer>> GetCustomer();
        public Task<IEnumerable<Acquisition>>GetRouting();
        public Task<IEnumerable<Acquisition>> GetReconsilation();
        public Task<IEnumerable<Department>> GetDepartment();

        public Task<IEnumerable<Department>> GetDepartmentByDescription(string Description);
        public Task<Acquisition> GetAcquisitionById(int AcquisitionID);
    }
}
