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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _DepartmentRepository;

        public DepartmentController(IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }
        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IEnumerable<Department>>GetDepartments()
        {
            try { 
            return await _DepartmentRepository.GetDepartments();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

    }
} 
