using Domain.DbEntities.EventParticipants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Participant.Query
{
    public record GetAllInvitationQuery():IRequest<List<EventParticipant>>;
    
}
