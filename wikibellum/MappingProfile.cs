using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Models;
using wikibellum.Models.ViewModels;

namespace wikibellum
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, EventCreateViewModel>().ReverseMap();
            CreateMap<List<EventParticipant>, EventCreateViewModel>().ReverseMap();
            CreateMap<Event, EventCreateViewModel>().IncludeMembers(p => p.Location, p => p.Participants).ReverseMap();
        }
    }
}
