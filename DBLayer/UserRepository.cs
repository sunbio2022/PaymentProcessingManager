using Microsoft.EntityFrameworkCore;
using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
using PaymentProcessingManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessingManager.DBLayer
{
    public class UserRepository : IUserRepository
    {
        private MyDBContext dbContext;

        public UserRepository(MyDBContext context)
        {
            dbContext = context;
        }
        public async Task<IEnumerable<UserList>> getUsersList()
        {
            try
            {
                return await dbContext.Users.Select(u => new UserList() { UserName = u.UserName, Email = u.Email, RoleName = u.Role.Name, DepartmentName = u.Department.Name }).AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public async Task<string> GetRoles(int roleId)
        //{
        //    try
        //    {
        //        return await dbContext.Roles.Where(r => r.Id == roleId).Select(r => r.Name).AsQueryable().FirstOrDefaultAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public async Task<IEnumerable<Role>> GetAllUserRoles()
        {
            try
            {
                return await dbContext.Roles.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        Task<IEnumerable<User>> IUserRepository.getUsersList()
        {
            throw new NotImplementedException();
        }
    }
}
