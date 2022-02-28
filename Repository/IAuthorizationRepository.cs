using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IAuthorizationRepository
    {
        public Task<IEnumerable<Acquisition>> GetAcquisitions();
        public Task<IEnumerable<AuthorizeStatus>> GetAuthorizeStatus();

        public Task<IEnumerable<Acquisition>> GetPostPayment();
    }
}
