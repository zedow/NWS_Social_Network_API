using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int? GuildId { get; set; }
    }
}
