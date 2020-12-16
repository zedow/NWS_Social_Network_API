using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Dtos
{
    //Ne contiendra seulement nom, prénom et id par exemple, pour éviter d'envoyer toutes les données on compte seulement afficher une liste de nom
    public class UserReadDto
    {
        public int Id;
        public string Name;
        public int Role;
    }
}
