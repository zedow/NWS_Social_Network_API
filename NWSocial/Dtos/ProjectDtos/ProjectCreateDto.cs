using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.ProjectDtos
{
    public class ProjectCreateDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DeadLine { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int? GuildId { get; set; }
    }
}
