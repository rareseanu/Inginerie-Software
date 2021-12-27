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
            CreateMap<DepartureDTO,Departure>();
            CreateMap<Departure,DepartureDTO>();
            CreateMap<RouteDTO,Route>();
            CreateMap<Route,RouteDTO>();
            CreateMap<SeatDTO,Seat>();
            CreateMap<Seat,SeatDTO>();
            CreateMap<StationDTO,Station>();
            CreateMap<Station,StationDTO>();
            CreateMap<TicketDTO,Ticket>();
            CreateMap<Ticket,TicketDTO>();
            CreateMap<TrainDTO,Train>();
            CreateMap<Train,TrainDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User,UserDTO>();       
            CreateMap<WagonDTO,Wagon>();       
            CreateMap<Wagon,WagonDTO>();       
        }
    }
}
