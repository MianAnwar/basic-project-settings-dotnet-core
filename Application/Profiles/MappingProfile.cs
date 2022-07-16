using Application.Features.Categories.Commands.CreateCateogry;
using Application.Features.Categories.Commands.CreateCateogry.DTO;
using Application.Features.Categories.Queries.GetCategoriesList.VM;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents.DTO;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents.VM;
using Application.Features.Events.Commands.CreateEvent;
using Application.Features.Events.Commands.UpdateEvent;
using Application.Features.Events.Queries.GetEventDetail.VM;
using Application.Features.Events.Queries.GetEventsExport.DTO;
using Application.Features.Events.Queries.GetEventsList.DTO;
using Application.Features.Events.Queries.GetEventsList.VM;
using Application.Features.Orders.Queries.GetOrdersForMonth.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            
            CreateMap<Event, EventExportDto>().ReverseMap();
            

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
