using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private MyDBContext _dbcontext;
        public LoginRepository(LoginRepository loginrepository)
        {
            _dbcontext = loginrepository;
        }
        public bool Authenticate(Credentials credentials)
        {
            try
            {
                bool exists = _dbContext.users.Where(u => u.UserName == credentials.UserName && u.Password == credentials.Password).AsQueryable().Any();
                return exists;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<string> GetRoleByName(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
