using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NWSocial.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public uint GoogleId { get; set; }
        public List<UserGuild> Guilds { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; }
    }
}
