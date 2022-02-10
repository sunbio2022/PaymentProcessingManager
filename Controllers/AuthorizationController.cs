using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRepository authorrep;
        public AuthorizationController(IAuthorizationRepository authorRepository)
        {
            authorrep = authorRepository;
        }

        [HttpGet]
        [Route("GetAcquisitions")]
        public async Task<IEnumerable<Acquisition>> GetAcquisitions()
        {
            try
            {
                return await authorrep.GetAcquisitions();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        [Route("GetAuthorizeStatus")]
        public async Task<IEnumerable<AuthorizeStatus>> GetAuthorizeStatus()
        {
            try
            {
                return await authorrep.GetAuthorizeStatus();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

}
