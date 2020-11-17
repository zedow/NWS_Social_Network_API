using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Seed
{
    public class ProjectSlotsSeed : IDbsetSeed
    {
        public void Seed(NWSContext context)
        {
            if (!context.ProjectSlots.Any())
            {
                context.ProjectSlots.AddRange(
                    new ProjectSlot
                    {
                        ProjectId = 1,
                        Role = "Chef de projet",
                    },
                    new ProjectSlot
                    {
                        ProjectId = 2,
                        Role = "Chef de projet",
                    },
                    new ProjectSlot
                    {
                        ProjectId = 3,
                        Role = "Chef de projet",
                    },
                    new ProjectSlot
                    {
                        ProjectId = 4,
                        Role = "Chef de projet",
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding ProjectSlots...Remove current data from database to launch seeding");
            }
        }
    }
}
