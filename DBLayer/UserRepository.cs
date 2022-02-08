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
            try
            {
                return await dbContext.Users.AsQueryable().ToListAsync();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }
    }
}
