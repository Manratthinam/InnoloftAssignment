using Domain.RequestEntities.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Event.Command
{
    public record EditEventCommand(EditEvent eventObject):IRequest<bool>;
    
}
