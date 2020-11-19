using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Payloads
{
    public class PProjectFiltering
    {
        public int? GuildId { get; set; }
        public string Filter { get; set; }
        public bool? IsClosed { get; set; }
        public string Role { get; set; }
    }
}
