using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Dtos.ProjectMemberDtos;

namespace NWSocial.Dtos.ProjectSlotDtos
{
    public class ProjectSlotReadDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public ProjectMemberForSlotReadDto ProjectMember { get; set; }
    }
}
