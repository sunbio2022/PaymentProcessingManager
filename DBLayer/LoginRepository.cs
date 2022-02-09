using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using PaymentProcessingManager.DBContexts;
using Microsoft.EntityFrameworkCore;

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

        public async Task<string> GetRoleByName(string userName)
        {
            int roleID = _dbcontext.Users.Where(u => u.UserName == userName).Select(u => u.RoleID).FirstOrDefault();
            if (roleID > 0)
            {
                return await _dbcontext.Roles.Where(r => r.Id == roleID).Select(r => r.Name).AsQueryable().FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>>GetUsers()
        {
            try {
                return await _dbcontext.Users.AsQueryable().ToListAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
       
    }
}
