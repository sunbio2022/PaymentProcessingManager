using PaymentProcessingManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> getUsersList();
        //public Task<string> GetRoles(int roleId);
        public Task<IEnumerable<Role>> GetAllUserRoles();
    }

}
