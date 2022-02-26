﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ServiceRegistryController : ControllerBase
    {
        private readonly IServiceRegistryRepository _serviceRegistryRepository;
        private MyDBContext _dbcontext;

        public ServiceRegistryController(IServiceRegistryRepository serviceRegistry)
        {
            _serviceRegistryRepository = serviceRegistry;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            try
            {
                return await _serviceRegistryRepository.GetDepartments();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        [Route("GetServiceRegistries")]
        public async Task<IEnumerable<ServiceRegistry>> GetServiceRegistries()
        {
            return await _serviceRegistryRepository.GetServiceRegistries();
        }

        [HttpGet]
        [Route("GetPaymentGateways")]
        public async Task<IEnumerable<PaymentGateway>> GetPaymentGateways()
        {
            try
            {
                return await _serviceRegistryRepository.GetPaymentGateways();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        [HttpPost]
        [Route("SaveServiceRegistry")]
        public async Task<ActionResult<ServiceRegistry>> SaveServiceRegistry(ServiceRegistry serviceRegistry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newService = await _serviceRegistryRepository.SaveServiceRegistry(serviceRegistry);
                return CreatedAtAction(nameof(GetServiceRegistries), new { id = newService.ServiceRegistryID }, newService);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            //if(!!ModelState.IsValid)
            //{
            //    var newService = await _serviceRegistryRepository.SaveService(SR);
            //    return CreatedAtAction(nameof(SaveService), new { id = newService.ServiceRegistryID },newService);
            //}
            //else
            //{
            //    return NoContent();
            //}
        }
    }
}
