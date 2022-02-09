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
    public class PaymentGatewayController : ControllerBase
    {
        private readonly IPaymentGatewayRepository _PaymentGatewayRepository;

        public PaymentGatewayController(IPaymentGatewayRepository PaymentGatewayRepository)
        {
            _PaymentGatewayRepository = PaymentGatewayRepository;
        }
        [HttpGet]
        [Route("GetPaymentGateways")]
        public async Task<IEnumerable<PaymentGateway>> GetPaymentGateways()
        {
            try
            {
                return await _PaymentGatewayRepository.GetPaymentGateways();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

    }
}
