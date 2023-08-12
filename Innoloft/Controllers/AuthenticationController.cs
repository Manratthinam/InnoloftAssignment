using Application.Core.Auth.LoginFn.Query;
using Application.Core.Auth.SignFn.Command;
using Domain.RequestEntities.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Innoloft.Controllers
{
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignIn userDetail)
        {
            try
            {
                await Mediator.Send(new SignInCommand(userDetail));
                return Ok("Account Created");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
             
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login loginUser)
        {
            try
            {
                var userInfo = await Mediator.Send(new CheckUserExistQuery(loginUser.Email));
                if (userInfo == null) { return BadRequest("No User Exist"); }
                string password = loginUser.Password;
                if (userInfo.Password != password) { return BadRequest("Password missmatch"); }
                var claim = new List<Claim>
            {
                new(ClaimTypes.Name,userInfo.UserName),
                new(ClaimTypes.Email,userInfo.Email),
                new(ClaimTypes.Sid,userInfo.UserId.ToString()),
            };
                var claimIdentity = new ClaimsIdentity(claim, "Identity.Application");
                await HttpContext.SignInAsync(
                    "Identity.Application",
                    new ClaimsPrincipal(claimIdentity),
                    new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(2),
                        IssuedUtc = DateTime.UtcNow,
                        IsPersistent = true,
                    });
                return Ok("Login Successful");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok("LogOut Successful");
        }
    }
}
