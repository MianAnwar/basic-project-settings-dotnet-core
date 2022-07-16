using Application.Features.Orders.Queries.GetOrdersForMonth.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrdersForMonth.VM
{
    public class PagedOrdersForMonthVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthDto> OrdersForMonth { get; set; }
    }
}
