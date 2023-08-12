using Application.Common.ServiceInterface;
using Domain.DbEntities.User;
using Domain.RequestEntities.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbServices.UserServices
{
    public class UserServices : IUserInterface
    {
        private InnoloftContext _dbContext;
        public UserServices(InnoloftContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddUsers(Users userInfo)
        {
            try
            {
               
                await _dbContext.AddAsync(userInfo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetUserUsignEmail(string email)
        {
            try
            {
                var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);
                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
