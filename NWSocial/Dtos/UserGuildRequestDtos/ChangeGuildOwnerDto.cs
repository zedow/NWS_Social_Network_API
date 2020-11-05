using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos.UserGuildRequestDtos
{
    public class ChangeGuildOwnerDto
    {
        public int CurrentUserOwnerId;
        public int NewUserOwnerId;
        public int GuildId;
    }
}
