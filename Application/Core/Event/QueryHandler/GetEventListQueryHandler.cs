using Application.Common.ServiceInterface;
using Application.Core.Event.Query;
using Domain.DbEntities.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Event.QueryHandler
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<Events>>
    {
        private IEventService _eventService;
        public GetEventListQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<List<Events>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int skip = request.eventSize.PageInation * request.eventSize.PageSize;
                int take = request.eventSize.PageSize;
                var events = await _eventService.GetEventList(skip, take);
                return events;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
