using Microsoft.AspNetCore.Mvc;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerReport;




        public CustomerController(ICustomerRepository customerReport)
        {
            _customerReport = customerReport;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IEnumerable<Customer>> getCustomers()
        {
            return await _customerReport.getCustomer();
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerReport.getCustomer();
        }

        [HttpGet]
        [Route("getCustomerReport")]
        public async Task<IEnumerable<Acquisition>> getCustomerReport(int CustomerID)
        {
            return await _customerReport.getCustomerReport(CustomerID);
        }

    }
}
