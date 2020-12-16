using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Payloads
{
    public class GuildMemberPayload
    {
        public int GuildId { get; set; }
        public int UserId { get; set; }
    }
}
