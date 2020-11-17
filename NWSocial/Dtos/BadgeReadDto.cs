using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos
{
    public class BadgeReadDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}
