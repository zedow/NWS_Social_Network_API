using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Classes;

namespace NWSocial.Payloads
{
    public class ProjectsPayload
    {
        public ProjectFilter Filter { get; set; }
        public Pagination Pagination { get; set; }
    }
}
