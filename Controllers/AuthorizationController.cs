using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles = "Department Head,Department Clerk")]
        [Route("GetAuthorizations")]
        public async Task<IEnumerable<Acquisition>> GetAuthorizations()
        {
            try
            {
                return await authorrep.GetAuthorizations();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Department Head,Department Clerk")]
        [Route("GetPostPayment")]
        public async Task<IEnumerable<Acquisition>> GetPostPayment()
        {
            try
            {
                return await authorrep.GetPostPayment();
            }
            catch (Exception ex)
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

        [HttpPut("authorizationStatus/{authorizestatus}/acquisitionID/{acquisition}")]
        [Route("UpdateAuthorizationStatus")]
        public async Task<int> UpdateAuthorizationStatus(int authorizationStatus, int acquisitionID)
        {
            return await authorrep.UpdateAuthorizationStatus(authorizationStatus, acquisitionID);
        }


        [HttpPut("acquisitionID/{acquisition}")]
        [Route("UpdateAuthorization")]
        public async Task<int> UpdateAuthorization(int acquisitionID)
        {
            return await authorrep.UpdateAuthorization(acquisitionID);
        }

    }

}
