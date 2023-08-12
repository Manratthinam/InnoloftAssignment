using Domain.DbEntities.Event;
using Domain.RequestEntities.Events;
using MediatR;


namespace Application.Core.Event.Query
{
    public record GetEventListQuery(FetchEvent eventSize):IRequest<List<Events>>;
    
}
