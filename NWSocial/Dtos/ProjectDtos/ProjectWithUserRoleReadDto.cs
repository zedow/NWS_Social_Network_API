using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.ProjectDtos
{
    public class ProjectWithUserRoleReadDto : ProjectReadDto
    {
        public string Role { get; set; }
        public int? GuildId { get; set; }
    }
}
