using Application.Common.Interface;
using Application.Common.ServiceInterface;
using Application.Core.Participant.Command;
using Domain.DbEntities.EventParticipants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Participant.CommandHandler
{
    public class BeParticipantCommandHandler : IRequestHandler<BeParticipantCommand, bool>
    {
        private ICurrentUser _currentUser;
        private IEventParticipant _eventParticipantService;
        public BeParticipantCommandHandler(ICurrentUser currentUser,IEventParticipant eventParticipant)
        {
            _currentUser = currentUser;
            _eventParticipantService = eventParticipant;
        }

        public async Task<bool> Handle(BeParticipantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int eventId = request.eventId;
                int currentUser = _currentUser.UserId;
                EventParticipant eventParticipantObj = new EventParticipant()
                {
                    EventId = eventId,
                    UserId = currentUser,
                    isParticipating = true,
                    createdBy = currentUser,
                    createdOn = DateTime.UtcNow,
                };
                var isParticipant = await _eventParticipantService.IncludeParticipant(eventParticipantObj);
                return isParticipant;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
