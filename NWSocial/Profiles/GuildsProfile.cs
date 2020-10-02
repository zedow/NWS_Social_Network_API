using AutoMapper;
using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Profiles
{
    public class GuildsProfile : Profile
    {
        public GuildsProfile()
        {
            // Source to target
            CreateMap<Guild, GuildReadDto>();
            CreateMap<GuildCreateDto, Guild>();
            CreateMap<GuildUpdateDto, Guild>();
            CreateMap<Guild, GuildUpdateDto>();
        }
    }
}
