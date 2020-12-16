using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Seed
{
    public class UsersSeed : IDbsetSeed
    {
        public void Seed(NWSContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.Add(new User { Id= 1,  Name = "Visiteur test", Role = 1 });
                context.Users.Add(new User { Id= 2,  Name = "Eleve test", Role = 2 });
                context.Users.Add(new User { Id= 3,  Name = "Admin test", Role = 4 });
                context.Users.Add(new User { Id= 4,  Name = "Moderateur test", Role = 3 });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding Users...Remove current data from database to launch seeding");
            }
        }
    }
}
