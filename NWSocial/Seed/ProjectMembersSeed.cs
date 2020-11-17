using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Seed
{
    public class ProjectMembersSeed : IDbsetSeed
    {
        public void Seed(NWSContext context)
        {
            if (!context.ProjectMembers.Any())
            {
                context.ProjectMembers.AddRange(
                    new ProjectMember
                    {
                        ProjectId = 1,
                        SlotId = 1,
                        UserId = 1
                    },
                    new ProjectMember
                    {
                        ProjectId = 2,
                        SlotId = 2,
                        UserId = 1
                    },
                    new ProjectMember
                    {
                        ProjectId = 3,
                        SlotId = 3,
                        UserId = 1
                    },
                    new ProjectMember
                    {
                        ProjectId = 4,
                        SlotId = 4,
                        UserId = 1
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding ProjectMembers...Remove current data from database to launch seeding");
            }
        }
    }
}
