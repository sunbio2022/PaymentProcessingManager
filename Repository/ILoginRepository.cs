using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface ILoginRepository
    {
        public bool Authenticate(Credentials credentials);
        public Task<string> GetRoleByName(string roleName);
        public Task<IEnumerable<User>> GetUsers();
    }
}
