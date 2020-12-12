using AutoMapper;
using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Profiles
{
    public class BadgesProfile : Profile
    {
        public BadgesProfile()
        {
            CreateMap<Badge, BadgeReadDto>();
        }
        
    }
}
