using MediatR;

namespace Application.Core.Auth.SignFn.Command
{
    public record SignInCommand(Domain.RequestEntities.Auth.SignIn userInfo):IRequest<bool>;
    
}
