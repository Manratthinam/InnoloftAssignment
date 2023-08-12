using Application.Common.ServiceInterface;
using Application.Core.Event.Query;
using Domain.DbEntities.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Event.QueryHandler
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, Events>
    {
        private IEventService _eventService;
        public GetEventQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<Events> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var eventInfo = await _eventService.GetEvent(request.eventId);
                return eventInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
