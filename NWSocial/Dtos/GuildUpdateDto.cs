﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos
{
    public class GuildUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
