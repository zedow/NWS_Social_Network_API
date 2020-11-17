using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Seed
{
    public class GuildsSeed : IDbsetSeed
    {
        public void Seed(NWSContext context)
        {
            if(!context.Guilds.Any())
            {
                Console.WriteLine("Seeding guilds");
                context.Guilds.AddRange(
                    new Guild
                    {
                        Id = 1,
                        Name = "Random guild 1",
                        Description = "Random description of guild 1"
                    },
                    new Guild
                    {
                        Id = 2,
                        Name = "Random guild 2",
                        Description = "Random description of guild 2"
                    },
                    new Guild
                    {
                        Id = 3,
                        Name = "Random guild 3",
                        Description = "Random description of guild 3"
                    },
                    new Guild
                    {
                        Id = 4,
                        Name = "Random guild 4",
                        Description = "Random description of guild 4"
                    },
                    new Guild
                    {
                        Id = 5,
                        Name = "Random guild 5",
                        Description = "Random description of guild 5"
                    },
                    new Guild
                    {
                        Id = 6,
                        Name = "Random guild 6",
                        Description = "Random description of guild 6"
                    },
                    new Guild
                    {
                        Id = 7,
                        Name = "Random guild 7",
                        Description = "Random description of guild 7"
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding Guilds...Remove current data from database to launch seeding");
            }
        }
    }
}
