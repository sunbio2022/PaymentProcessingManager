﻿using Microsoft.EntityFrameworkCore;
using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.DBLayer
{
    public class ServiceRegistryRepository : IServiceRegistryRepository
    {
        private MyDBContext _dbcontext;
        public ServiceRegistryRepository(MyDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dbcontext.Departments.AsQueryable().ToListAsync();
        }
        public async Task<IEnumerable<PaymentGateway>> GetPaymentGateways()
        {
            return await _dbcontext.PaymentGateways.AsQueryable().ToListAsync();
        }
        public async Task<IEnumerable<ServiceRegistry>> GetServiceRegistries()
        {
            return await _dbcontext.ServiceRegistry.AsQueryable().ToListAsync();
        }

        public async Task<ServiceRegistry> SaveServiceRegistry(ServiceRegistry serviceRegistry)
        {
            _dbcontext.ServiceRegistry.Add(serviceRegistry);
            await _dbcontext.SaveChangesAsync();
            return serviceRegistry;
        }

    }
}