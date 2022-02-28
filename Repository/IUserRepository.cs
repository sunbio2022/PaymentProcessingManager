using PaymentProcessingManager.Model;
using PaymentProcessingManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserList>> getUsersList();
        //public Task<string> GetRoles(int roleId);
        public Task<IEnumerable<Role>> GetAllUserRoles();
    }

}
