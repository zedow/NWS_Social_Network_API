using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.ProjectMemberDtos
{
    public class ProjectMemberCreateDto
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
