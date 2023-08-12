using Application.Common.Interface;
using Application.Common.ServiceInterface;
using Application.Core.Event.Command;
using Domain.DbEntities.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Event.CommandHandler
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, bool>
    {
        private IEventService _eventService;
        private ICurrentUser _currentUser;
        public CreateEventCommandHandler(IEventService eventService,ICurrentUser currentUser)
        {
            _eventService = eventService;
            _currentUser = currentUser;
        }
        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventsInfo = request.eventArg;
                Events events= new Events() {
                    CreatedBy = _currentUser.UserId,
                    CreatedOn = DateTime.UtcNow,
                    Description = eventsInfo.EventDescription,
                    EventTitle = eventsInfo.EventTitle,
                    EventStartDate=eventsInfo.StartTime.ToUniversalTime(),
                    EventEndDate = eventsInfo.EndTime.ToUniversalTime(),
                    ModifiedBy = _currentUser.UserId,
                    ModifiedOn = DateTime.UtcNow,
                };
                var isEventCreated = await _eventService.CreateEvent(events);
                return isEventCreated;
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
