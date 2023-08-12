using Application.Core.Participant.Command;
using Application.Core.Participant.Query;
using Domain.DbEntities.Event;
using Domain.RequestEntities.EventParticipation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Innoloft.Controllers
{
    public class ParticipantController : BaseController<ParticipantController>
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BeParticipant(int eventId)
        {
            try
            {
                var addParticipant = await Mediator.Send(new BeParticipantCommand(eventId));
                return addParticipant ? Ok("Added as Participant") : BadRequest("Unable to add as Participant");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendParticipationInvitation([FromBody] ParticipationInvitation participantInvites)
        {
            try
            {
                var sendInvitation = await Mediator.Send(new SendInvitationCommand(participantInvites.eventId, participantInvites.userIds));
                return Ok("Invitation Send Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllInvitation()
        {
            try
            {
                var userDetails = await Mediator.Send(new GetAllInvitationQuery());
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                return Ok(JsonConvert.SerializeObject(userDetails, this.GetType(), Formatting.Indented, settings));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
