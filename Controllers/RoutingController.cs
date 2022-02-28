using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessingManager.DBContexts;
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
        [Route("GetCustomer")]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _routingRepository.GetCustomer();
        }

        [HttpGet]
        [Route("GetRouting")]
        public async Task<IEnumerable<Acquisition>> GetRouting()
        {
            return await _routingRepository.GetRouting();
        }

        [HttpGet]
        [Route("GetReconsilation")]
        public async Task<IEnumerable<Acquisition>> GetReconsilation()
        {
            return await _routingRepository.GetReconsilation();
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

        [HttpGet("{id}")]
        [Route("GetAcquisitionById")]
        public async Task<ActionResult<Acquisition>> GetAcquisitionById(int AcquisitionID)
        {
            return await _routingRepository.GetAcquisitionById(AcquisitionID);
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public ActionResult UpdateDepartment([FromBody] Acquisition acquisition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                MyDBContext dbcontext = new MyDBContext();
                var sq = dbcontext?.Acquisition?.Where(a => a.AcquisitionID== acquisition.AcquisitionID).FirstOrDefault();
                //dbcontext.Entry(acquisition).Property(s=>s.DepartmentID).IsModified=true;
                if (sq != null)
                {
                    sq.DepartmentID = acquisition.DepartmentID;
                    dbcontext.SaveChanges();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            //dbcontext.Acquisition.Add(acquisition);
            //await dbcontext.SaveChangesAsync();
        }
    }
}

