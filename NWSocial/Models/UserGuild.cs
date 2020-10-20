using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Models
{
    public class UserGuild
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GuildId { get; set; }
        public Guild Guild { get; set; }

        public string Role { get; set; }
    }
}
