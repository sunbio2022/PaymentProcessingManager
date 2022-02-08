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
    public class AcquisitionController : ControllerBase
    {
        private readonly IAcquisitionRepository _acquisitionRepository;

        public AcquisitionController(IAcquisitionRepository acquisitionRepository)
        {
            _acquisitionRepository = acquisitionRepository;
        }

        [HttpGet]
        [Route("GetAcquisition")]
        public async Task<IEnumerable<Acquisition>> GetAcquisition()
        {
            return await _acquisitionRepository.GetAcquisition();
        }
    }
}
