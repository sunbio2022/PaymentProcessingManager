using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using PaymentProcessingManager.DBContexts;

namespace PaymentProcessingManager.DBLayer
{
    public class LoginRepository : ILoginRepository
    {
        private MyDBContext _dbcontext;
        public LoginRepository(MyDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Authenticate(Credentials credentials)
        {
            try
            {
                bool exists = _dbcontext.Users.Where(u => u.UserName == credentials.UserName && u.Password == credentials.Password).AsQueryable().Any();
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
