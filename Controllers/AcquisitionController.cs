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

        [HttpPut("id/{userId}")]
        [Route("UpdateAcquisition")]
        public async Task<int> UpdateAcquisition(int id)
        {
            return await _acquisitionRepository.UpdateAcquisition(id);
        }

        [HttpPut("customer/{customers}/account/{accounts}/acquisitionIDs{acquisitionIDs}")]
        [Route("UpdateCustomerandAccount")] 
        public async Task<int> UpdateCustomerandAccount(string customer, string account, string acquisitionID)
        {
            return await _acquisitionRepository.UpdateCustomerandAccount(customer, account, acquisitionID);
        }

        [HttpPut("acquisitionID/{acquisition}")]
        [Route("UpdateReconsilation")]
        public async Task<int> UpdateReconsilation(int acquisitionID)
        {
            return await _acquisitionRepository.UpdateReconsilation(acquisitionID);
        }

        [HttpPut("acquisitionID/{acquisition}")]
        [Route("UpdatePostPayment")]
        public async Task<int> UpdatePostPayment(int acquisitionID)
        {
            return await _acquisitionRepository.UpdatePostPayment(acquisitionID);
        }
    }
}
