﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.ProjectDtos
{
    public class ProjectReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DeadLine { get; set; }
        public string Description { get; set; }
        public bool isClosed { get; set; }
    }
}
