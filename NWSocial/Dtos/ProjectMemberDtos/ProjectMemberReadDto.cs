using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Dtos.ProjectDtos;
using NWSocial.Dtos.ProjectSlotDtos;
using NWSocial.Dtos;

namespace NWSocial.Dtos.ProjectMemberDtos
{
    public class ProjectMemberReadDto
    {
        public ProjectSlotReadDto Slot { get; set; }
    }
}
