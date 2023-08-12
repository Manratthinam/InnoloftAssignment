using Application.Common.Interface;
using Application.Common.ServiceInterface;
using Application.Core.Participant.Query;
using Domain.DbEntities.EventParticipants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Participant.QueryHandler
{
    public class GetAllInvitationQueryHandler : IRequestHandler<GetAllInvitationQuery, List<EventParticipant>>
    {
        private readonly IEventParticipant _eventParticipantService;
        private readonly ICurrentUser _currentUser;
        public GetAllInvitationQueryHandler(IEventParticipant eventParticipantService, ICurrentUser currentUser)
        {
            _eventParticipantService = eventParticipantService;
            _currentUser = currentUser;
        }

        public async Task<List<EventParticipant>> Handle(GetAllInvitationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userInfo = await _eventParticipantService.GetAllInvitation(_currentUser.UserId);
                return userInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
