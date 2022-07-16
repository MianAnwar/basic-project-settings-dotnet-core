using Application.Features.Events.Queries.GetEventDetail.VM;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
