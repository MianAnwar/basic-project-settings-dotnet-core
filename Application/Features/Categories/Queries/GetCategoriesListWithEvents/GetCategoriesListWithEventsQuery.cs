using System;
using System.Collections.Generic;
using MediatR;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents.VM;

namespace Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
