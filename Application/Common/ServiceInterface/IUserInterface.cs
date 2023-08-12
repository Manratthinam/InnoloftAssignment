using Domain.DbEntities.User;
using Domain.RequestEntities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ServiceInterface
{
    public interface IUserInterface
    {
        Task<bool> AddUsers(Users userInfo);
        Task<Users> GetUserUsignEmail(string email);
    }
}
