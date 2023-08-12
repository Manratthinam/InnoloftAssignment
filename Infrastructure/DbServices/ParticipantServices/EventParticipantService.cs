using Application.Common.ServiceInterface;
using Domain.DbEntities.EventParticipants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.DbServices.ParticipantServices
{
    public class EventParticipantService : IEventParticipant
    {
        private InnoloftContext _context;
        public EventParticipantService(InnoloftContext context)
        {
            _context = context;
        }

        public async Task<List<EventParticipant>> GetAllInvitation(int userId)
        {
            try
            {
                var userDetail = _context.EventParticipants.Include(x=>x.Event)
                    .Where(x => x.UserId == userId && x.gotInvitation == false)
                    .ToList();
                return userDetail;                        
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IncludeParticipant(EventParticipant eventParticipant)
        {
            try
            {
                await _context.AddAsync(eventParticipant);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SendInvitation(List<EventParticipant> eventParticipantList)
        {
            try
            {
                eventParticipantList.ForEach(async x =>
                {
                    await _context.AddAsync(x);
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
