using AutoMapper;
using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            // Source to target
            CreateMap<Post, PostReadDto>();
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<Post, PostUpdateDto>();
        }
    }
}
