using Application.Core.Event.Command;
using Application.Core.Event.Query;
using Domain.RequestEntities.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Innoloft.Controllers
{
    public class EventsController : BaseController<EventsController>
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] AddNewEvent eventArgs)
        {
            try
            {
                var isEventCreated = await Mediator.Send(new CreateEventCommand(eventArgs));
                return isEventCreated ? Ok("created event") : BadRequest("Unable to create event");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
     
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetEventList([FromBody] FetchEvent fetchEvent)
        {
            try
            {
                var events = await Mediator.Send(new GetEventListQuery(fetchEvent));
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                return Ok(JsonConvert.SerializeObject(events,this.GetType(),Formatting.Indented,settings));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEvent(int eventId)
        {
            try
            {
                var eventInfo = await Mediator.Send(new GetEventQuery(eventId));
                return Ok(eventInfo);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditEvent([FromBody] EditEvent events)
        {
            try
            {
                var isUpdated = await Mediator.Send(new EditEventCommand(events));
                return isUpdated ? Ok("Event Updated Successfully") : BadRequest("Update Failed");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
