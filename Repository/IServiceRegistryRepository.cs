using PaymentProcessingManager.DBLayer;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IServiceRegistryRepository
    {
        public Task<IEnumerable<Department>> GetDepartments();
        public Task<IEnumerable<PaymentGateway>> GetPaymentGateways();

        public Task<IEnumerable<ServiceRegistry>> GetServiceRegistry();

        public Task<ServiceRegistry> SaveServiceRegistry(ServiceRegistry serviceRegistry);
        //public Task<ServiceRegistry> SaveService(ServiceRegistryModel SR);
    }
}
