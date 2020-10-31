using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.UserGuildRequestDtos
{
    // DTO pour l'acceptation d'un user dans une guilde
    public class UserGuildAcceptDto
    {
        public int UserId { get; set; }
        public int GuildId { get; set; }
    }
}
