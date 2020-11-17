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
                context.Users.Add(new User { Id= 1,  Name = "User test" });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding Users...Remove current data from database to launch seeding");
            }
        }
    }
}
