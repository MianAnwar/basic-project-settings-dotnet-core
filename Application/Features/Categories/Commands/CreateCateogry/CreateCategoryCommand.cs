using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using Application.Features.Categories.Commands.CreateCateogry.Response;

namespace Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
