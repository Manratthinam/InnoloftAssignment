using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestEntities.EventParticipation
{
    public class ParticipationInvitation
    {
        public int eventId { get; set; }
        public List<int> userIds { get; set; }
    }
}
