using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos
{
    public class UserGuildCreateRequestDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GuildId { get; set; }
    }
}
