using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesList.VM
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
