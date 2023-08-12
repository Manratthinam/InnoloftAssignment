using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestEntities.Events
{
    public class EditEvent
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartDate { get;set; }
        public DateTime EventEndDate { get;set; }

    }
}
