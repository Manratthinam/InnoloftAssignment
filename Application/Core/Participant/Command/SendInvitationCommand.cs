using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Participant.Command
{
    public record SendInvitationCommand(int eventId,List<int> userIds):IRequest<bool>;
    
}
