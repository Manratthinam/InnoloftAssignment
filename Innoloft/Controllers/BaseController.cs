using Application.Common.Interface;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Innoloft.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController<T>:ControllerBase where T:BaseController<T>
    {
        private IMediator? mediatorInstance;
        private ICurrentUser currentUserInstance;
        protected IMediator Mediator => mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ICurrentUser currentUser => currentUserInstance ??= HttpContext.RequestServices.GetService<ICurrentUser>();
    }
}
