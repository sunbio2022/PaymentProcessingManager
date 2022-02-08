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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userrep;
        public UsersController(IUserRepository userRepository)
        {
            userrep = userRepository;
        }
        [HttpGet]
        [Route("getUsersList")]
        public async Task<IEnumerable<User>> getUsersList()
        {
            return await userrep.getUsersList();
        }
    }
}