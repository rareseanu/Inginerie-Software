using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.Helpers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LineDTO, Line>();
            CreateMap<Line, LineDTO>();
            CreateMap<DepartureDTO, Departure>()
                .ForMember(d => d.ArrivalTime,
                    o => o.MapFrom(src => src.ArrivalTime.TimeOfDay))
                .ForMember(d => d.DepartureTime,
                    o => o.MapFrom(src => src.DepartureTime.TimeOfDay));
            CreateMap<Departure, DepartureDTO>()
                .ForMember(d => d.ArrivalTime,
                    o => o.MapFrom(src => new DateTime(src.ArrivalTime.Ticks))) 
                .ForMember(d => d.DepartureTime,
                    o => o.MapFrom(src => new DateTime(src.DepartureTime.Ticks)));
            CreateMap<RouteDTO, Route>();
            CreateMap<Route, RouteDTO>();
            CreateMap<StationDTO, Station>();
            CreateMap<Station, StationDTO>();
            CreateMap<TicketDTO, Ticket>();
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TrainDTO, Train>();
            CreateMap<Train, TrainDTO>();
            CreateMap<UserDTO, User>().ForMember(p=>p.Password,o=>o.MapFrom(src=>src.OldPassword));
            CreateMap<User, UserDTO>().ForMember(p => p.OldPassword, o => o.MapFrom(src => src.Password));
            CreateMap<WagonDTO, Wagon>();
            CreateMap<Wagon, WagonDTO>();
        }
    }
}
