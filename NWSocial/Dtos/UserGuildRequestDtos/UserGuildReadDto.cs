using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.UserGuildRequestDtos
{
    public class UserGuildReadDto
    {
        public string Role { get; set; }
        public UserReadDto User { get; set; }
    }
}
