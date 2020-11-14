using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NWSocial.Dtos.ProjectDtos;
using NWSocial.Dtos.ProjectMemberDtos;
using NWSocial.Models;
using NWSocial.Dtos.ProjectRequestDtos;
using NWSocial.Dtos.ProjectSlotDtos;

namespace NWSocial.Profiles
{
    public class ProjectProfiles : Profile
    {
        public ProjectProfiles()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectReadDto>();

            CreateMap<ProjectMember, ProjectMemberReadDto>();
            CreateMap<ProjectMemberCreateDto, ProjectMember>();
            CreateMap<ProjectMember, ProjectMemberForSlotReadDto>();

            CreateMap<ProjectRequest, ProjectRequestAfterCreationReadDto>();
            CreateMap<ProjectRequestCreateDto, ProjectRequest>();
            CreateMap<ProjectRequestUpdateDto, ProjectRequest>();
            CreateMap<ProjectRequest, ProjectRequestUpdateDto>();

            CreateMap<ProjectSlot, ProjectSlotReadDto>();
            CreateMap<ProjectSlotCreateDto, ProjectSlot>();
        }
    }
}
