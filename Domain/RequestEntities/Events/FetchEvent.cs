using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestEntities.Events
{
    public class FetchEvent
    {
        public int PageInation { get; set; }
        public int PageSize { get; set; }
    }
}
