using Microsoft.AspNetCore.Http;
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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountReport;
        public AccountController(IAccountRepository accountReport)
        {
            _accountReport = accountReport;
        }

        [HttpGet]
        [Route("GetServiceRegistry")]
        public async Task<IEnumerable<ServiceRegistry>> GetServiceRegistry()
        {
            return await _accountReport.GetServiceRegistry();
        }

        [HttpGet]
        [Route("GetServiceRegistryByMerchantID")]
        public async Task<IEnumerable<Acquisition>> GetServiceRegistryByMerchantID(int serviceregistryID)
        {
            return await _accountReport.GetServiceRegistryByMerchantID(serviceregistryID);
        }
    }
}
