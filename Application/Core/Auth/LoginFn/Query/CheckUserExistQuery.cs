using Domain.DbEntities.User;
using MediatR;

namespace Application.Core.Auth.LoginFn.Query
{
    public record CheckUserExistQuery(string Email):IRequest<Users>;
    
}
