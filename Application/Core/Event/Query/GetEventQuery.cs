using Domain.DbEntities.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Event.Query
{
    public record GetEventQuery(int eventId):IRequest<Events>;
    
}
