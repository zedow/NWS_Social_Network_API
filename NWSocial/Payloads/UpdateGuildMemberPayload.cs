using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using NWSocial.Dtos.UserGuildRequestDtos;

namespace NWSocial.Payloads
{
    public class UpdateGuildMemberPayload : GuildMemberPayload
    {
        public JsonPatchDocument<UserGuildRequestUpdateDto> PatchDocument { get; set; }
    }
}
