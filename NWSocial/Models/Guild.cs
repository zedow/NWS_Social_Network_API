using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Models
{
    public class Guild
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<UserGuild> Users { get; set; }
        public List<Post> Posts { get; set; }
        public List<Project> Projects { get; set; }
    }
}
