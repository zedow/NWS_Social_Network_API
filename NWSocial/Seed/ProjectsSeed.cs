using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Seed
{
    public class ProjectsSeed : IDbsetSeed
    {
        public void Seed(NWSContext context)
        {
            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Id = 1,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        IsPrivate = false,
                        GuildId = null
                    },
                    new Project
                    {
                        Id = 2,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        IsPrivate = false,
                        GuildId = 1
                    },
                    new Project
                    {
                        Id = 3,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        IsPrivate = true,
                        GuildId = 1
                    },
                    new Project
                    {
                        Id = 4,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        IsPrivate = true,
                        GuildId = null
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding Projects...Remove current data from database to launch seeding");
            }
        }
    }
}
