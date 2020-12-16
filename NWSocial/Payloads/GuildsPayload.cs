using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Classes;

namespace NWSocial.Payloads
{
    public class GuildsPayload
    {
        public Pagination Pagination { get; set; }
        public Filter Filter { get; set; }
    }
}
