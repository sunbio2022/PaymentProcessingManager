using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IAuthorizationRepository
    {
        public Task<IEnumerable<Acquisition>> GetAuthorizations();
        public Task<IEnumerable<AuthorizeStatus>> GetAuthorizeStatus();

        public Task<IEnumerable<Acquisition>> GetPostPayment();
        public Task<int> UpdateAuthorization(int acquisitionID);

        public Task<int> UpdateAuthorizationStatus(int authorizationStatus, int acquisitionID);
    }
}
