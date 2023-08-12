using Domain.DbEntities.Event;
using Domain.DbEntities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbEntities.EventParticipants
{
    [Table("EventParticipants")]
    public class EventParticipant
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get;set; }  
        public bool isParticipating { get; set; }
        public bool gotInvitation { get; set; }
        public int gotInviteFrom { get; set; }
        public DateTime createdOn { get; set; }
        public int createdBy { get;set; }
        public Events Event { get; set; }
        public Users User { get; set; } 
    }
}
