using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using PaymentProcessingManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userrep;
        public UsersController(IUserRepository userRepository)
        {
            userrep = userRepository;
        }

        [HttpGet]
        [Route("getUsersList")]
        public async Task<IEnumerable<UserList>> getUsersList()
        {
            try { 
            return await userrep.getUsersList();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }

        //[HttpGet]
        //[Route("GetRoles")]
        //public async Task<IActionResult> GetRoles(int roleId)
        //{
        //    try
        //    {
        //        string role = await userrep.GetRoles(roleId);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        [HttpGet]
        [Route("GetAllUserRoles")]
        public async Task<IEnumerable<Role>> GetAllUserRoles()
        {
            try
            {
                return await userrep.GetAllUserRoles();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}