using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using NWSocial.Dtos.ProjectRequestDtos;

namespace NWSocial.Payloads
{
    public class ProjectRequestPayload
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int SlotId { get; set; }
        public JsonPatchDocument<ProjectRequestUpdateDto> PatchDocument { get; set; }
    }
}
