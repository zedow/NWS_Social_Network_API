using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set;  }
        public uint GoogleId { get; set; }
        public List<UserGuild> Guilds { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; }
    }
}
