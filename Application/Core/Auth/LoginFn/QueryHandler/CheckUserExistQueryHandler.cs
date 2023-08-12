using Application.Common.ServiceInterface;
using Application.Core.Auth.LoginFn.Query;
using Domain.DbEntities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Auth.LoginFn.QueryHandler
{
    public class CheckUserExistQueryHandler : IRequestHandler<CheckUserExistQuery, Users>
    {
        private IUserInterface _userService;
        public CheckUserExistQueryHandler(IUserInterface userService)
        {
            _userService = userService;
        }

        public async Task<Users> Handle(CheckUserExistQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.GetUserUsignEmail(request.Email);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
