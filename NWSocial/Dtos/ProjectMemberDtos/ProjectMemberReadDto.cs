using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Dtos.ProjectDtos;
using NWSocial.Dtos;

namespace NWSocial.Dtos.ProjectMemberDtos
{
    public class ProjectMemberReadDto
    {
        public ProjectReadDto Project { get; set; }
        public UserReadDto User { get; set; }
        public string Role { get; set; }
    }
}
