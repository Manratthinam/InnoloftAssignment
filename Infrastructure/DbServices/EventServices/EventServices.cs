using Application.Common.ServiceInterface;
using Domain.DbEntities.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbServices.EventServices
{
    public class EventServices : IEventService
    {
        private InnoloftContext _dbContext;
        public EventServices(InnoloftContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateEvent(Events events)
        {
            try
            {
                await _dbContext.AddAsync(events);
                await _dbContext.SaveChangesAsync();   
                return true;
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<Events> GetEvent(int eventId)
        {
            try
            {
                var eventInfo = await _dbContext.Events.FirstOrDefaultAsync(e=>e.EventId == eventId);
                return eventInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Events>> GetEventList(int skip, int take)
        {
            try
            {
                var events = await _dbContext.Events.Skip(skip).Take(take).ToListAsync();
                return events;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateEvent(Events events)
        {
            try
            {
                _dbContext.Update(events);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
