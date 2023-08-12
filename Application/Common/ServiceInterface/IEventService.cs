using Domain.DbEntities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ServiceInterface
{
    public interface IEventService
    {
        Task<bool> CreateEvent(Events events);
        Task<List<Events>> GetEventList(int skip,int take);
        Task<Events> GetEvent(int eventId);
        Task<bool> UpdateEvent(Events events);
    }
}
