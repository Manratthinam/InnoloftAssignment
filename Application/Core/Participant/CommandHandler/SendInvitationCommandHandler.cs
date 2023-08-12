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
    public class SendInvitationCommandHandler : IRequestHandler<SendInvitationCommand, bool>
    {
        private readonly IEventParticipant _eventParticipantService;
        private readonly ICurrentUser _currentUser;
        public SendInvitationCommandHandler(IEventParticipant eventParticipantService, ICurrentUser currentUser)
        {
            _eventParticipantService = eventParticipantService;
            _currentUser = currentUser;
        }
        public async Task<bool> Handle(SendInvitationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int eventId = request.eventId;
                List<EventParticipant> lstEvent = new List<EventParticipant>();
                EventParticipant eventParticipantObj = new EventParticipant();
                foreach (var item in request.userIds)
                {
                    eventParticipantObj = new EventParticipant()
                    {
                        EventId = eventId,
                        UserId = item,
                        gotInvitation = true,
                        gotInviteFrom=_currentUser.UserId,
                        createdBy = _currentUser.UserId,
                        createdOn = DateTime.UtcNow,
                    };
                    lstEvent.Add(eventParticipantObj);
                }
                var inviteSend = await _eventParticipantService.SendInvitation(lstEvent);
                return inviteSend;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
