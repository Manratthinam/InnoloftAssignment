using Domain.DbEntities.EventParticipants;
using Domain.DbEntities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbEntities.Event
{
    [Table("Events")]
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string EventTitle { get;set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get;set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set;}

        public ICollection<EventParticipant> EventParticipant { get; set; }

    }
}
