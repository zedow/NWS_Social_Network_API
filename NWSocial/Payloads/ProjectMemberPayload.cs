﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Payloads
{
    public class ProjectMemberPayload
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
