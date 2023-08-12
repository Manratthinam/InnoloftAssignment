using Application.Common.Interface;
using Application.Common.ServiceInterface;
using Application.Core.Event.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Event.CommandHandler
{
    public class EditEventCommandHandler : IRequestHandler<EditEventCommand, bool>
    {
        private IEventService _eventService;
        private ICurrentUser _currentUser;
        public EditEventCommandHandler(IEventService eventService,ICurrentUser currentUser)
        {
            _eventService = eventService;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(EditEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedEventObject = request.eventObject;
                var eventInfo = await _eventService.GetEvent(updatedEventObject.EventId);
                eventInfo.EventStartDate = updatedEventObject.EventStartDate.ToUniversalTime();
                eventInfo.EventEndDate = updatedEventObject.EventEndDate.ToUniversalTime();
                eventInfo.EventTitle = updatedEventObject.EventTitle;
                eventInfo.Description = updatedEventObject.EventDescription;
                eventInfo.ModifiedOn = DateTime.UtcNow;
                eventInfo.ModifiedBy = _currentUser.UserId;

                var isUpdated = await _eventService.UpdateEvent(eventInfo);
                return isUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
