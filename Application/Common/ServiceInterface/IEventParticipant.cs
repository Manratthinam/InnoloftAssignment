using Domain.DbEntities.EventParticipants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ServiceInterface
{
    public interface IEventParticipant
    {
        Task<bool> IncludeParticipant(EventParticipant eventParticipant);
        Task<bool> SendInvitation(List<EventParticipant> eventParticipantList);
        Task<List<EventParticipant>> GetAllInvitation(int userId);
    }
}
