using AutoMapper;
using NWSocial.Dtos;
using NWSocial.Dtos.UserGuildRequestDtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Profiles
{
    public class UserGuildProfile : Profile
    {
        public UserGuildProfile()
        {
            CreateMap<UserGuildCreateRequestDto, UserGuild>();
            CreateMap<UserGuildRequestUpdateDto, UserGuild>();
            CreateMap<User, UserGuildReadDto>();
        }
    }
}
