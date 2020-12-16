using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Classes
{
    public class ProjectFilter : Filter
    {
        public int? GuildId { get; set; }
        public bool? IsPrivate { get; set; }
        public string Role { get; set; }
    }
}
