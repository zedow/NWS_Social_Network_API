using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Dtos;
using NWSocial.Dtos.ProjectSlotDtos;

namespace NWSocial.Dtos.ProjectRequestDtos
{
    public class ProjectRequestAfterCreationReadDto
    {
        public string Status { get; set; }
        public UserReadDto User { get; set; }
    }
}
