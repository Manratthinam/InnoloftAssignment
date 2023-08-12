using Application.Common.ServiceInterface;
using Application.Core.Auth.SignFn.Command;
using Domain.DbEntities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Auth.SignIn.CommandHandler
{
    public class SIgnInCommandHandler : IRequestHandler<SignInCommand, bool>
    {
        private IUserInterface _userService;
        public SIgnInCommandHandler(IUserInterface userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var userInfo = request.userInfo;
                Users user = new Users()
                {
                    UserName = userInfo.UserName,
                    Email = userInfo.Email,
                    Password = userInfo.Password,
                };
                var isUserCreated = await _userService.AddUsers(user);
                return isUserCreated;
            }
            catch (Exception ex){ throw ex; }
            
        }
    }
}
