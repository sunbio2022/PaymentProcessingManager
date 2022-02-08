using Microsoft.EntityFrameworkCore;
using PaymentProcessingManager.DBContexts;
using PaymentProcessingManager.Model;
using PaymentProcessingManager.Repository;
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
        public async Task<IEnumerable<User>> getUsersList()
        {
            User user = new User();
            //user= await dbContext.Users.AsQueryable().FirstOrDefaultAsync();
            return await dbContext.Users.AsQueryable().ToListAsync();
            //dbContext.Users.Select(u => new { UserName = u.UserName, Email = u.Email, DepartmentName = u.Department.Name, RoleName = u.Role.Name }).AsQueryable().ToListAsync();
            //var role = dbContext.Roles.Where(r => r.Id == user.RoleID).Select(r => r.Name).AsQueryable().ToListAsync();
            //return await dbContext.Users.AsQueryable().ToListAsync();
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
    }
}
