using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NWSocial.Seed
{
    public static class DbSeed
    {
        public static void PrepDb(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<NWSContext>());
            }
        }

        public static void SeedData(NWSContext context)
        {
            List<IDbsetSeed> seeds = new List<IDbsetSeed>
            {
                new UsersSeed(),
                new GuildsSeed(),
                new PostsSeed(),
                new ProjectsSeed(),
                new ProjectSlotsSeed(),
                new ProjectMembersSeed()
            };
            seeds.ForEach(s => s.Seed(context));
        }
    }
}
