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
    public class RoutingController : ControllerBase
    {
        private readonly IRoutingRepository _routingRepository;

        public RoutingController(IRoutingRepository routingRepository)
        {
            _routingRepository = routingRepository;
        }

        [HttpGet]
        [Route("GetRouting")]
        public async Task<IEnumerable<Acquisition>> GetRouting()
        {
            return await _routingRepository.GetRouting();
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _routingRepository.GetDepartment();
        }

        [HttpGet]
        [Route("GetDepartmentByDescription")]
        public async Task<IEnumerable<Department>> GetDepartmentByDescription(string description)
        {
            return await _routingRepository.GetDepartmentByDescription(description);
        }
    }
}

