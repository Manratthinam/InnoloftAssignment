using Domain.DbEntities.Event;
using Domain.DbEntities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventParticipantEntity
    {
        public int eventId { get; set; }
        public List<UserEntity> Users { get; set; }
    }
    
}
