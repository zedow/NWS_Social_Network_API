using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos
{
    // Classe permettant le mapping du model Guild (permet de retourner l'objet sans la description dans l'exemple suivant)
    public class GuildReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
