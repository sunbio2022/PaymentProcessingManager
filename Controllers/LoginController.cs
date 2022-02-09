using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        [Route("Authentication")]
        public async Task<IActionResult> Authentication([FromBody] Credentials credentials)
        {
            try
            {
                bool status = _loginRepository.Authenticate(credentials);
                if (status)
                {
                    string role = await _loginRepository.GetRoleByName(credentials.UserName);
                    return Ok(role);
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new String("Incorrect Username and password"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
