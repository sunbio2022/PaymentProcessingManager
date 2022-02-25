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
    public class ServiceRegistryController : ControllerBase
    {
        private readonly IServiceRegistryRepository _serviceRegistryRepository;

        public ServiceRegistryController(IServiceRegistryRepository serviceRegistry)
        {
            _serviceRegistryRepository = serviceRegistry;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            try
            {
                return await _serviceRegistryRepository.GetDepartments();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        [Route("GetServiceRegistry")]
        public async Task<IEnumerable<ServiceRegistry>> GetServiceRegistry()
        {
            return await _serviceRegistryRepository.GetServiceRegistry();
        }

        [HttpGet]
        [Route("GetPaymentGateways")]
        public async Task<IEnumerable<PaymentGateway>> GetPaymentGateways()
        {
            try
            {
                return await _serviceRegistryRepository.GetPaymentGateways();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("AddServiceRegistry")]
        public async Task<IActionResult> AddServiceRegistry([FromBody] ServiceRegistry ServiceRegistry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newService = await _serviceRegistryRepository.SaveServiceRegistry(ServiceRegistry);
                return CreatedAtAction(nameof(GetServiceRegistry), new { id = newService.ServiceRegistryID }, newService);
                return CreatedAtAction(nameof(GetServiceRegistry), new { id = newService.ServiceRegistryID }, newService);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
