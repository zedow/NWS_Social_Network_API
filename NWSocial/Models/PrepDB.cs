using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NWSocial.Data;

namespace NWSocial.Models
{
    public static class PrepDB
    {
        public static void PrepDb(IApplicationBuilder app)
        { 
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<NWSContext>());
            }
        }

        public static void SeedData(NWSContext context)
        {
            System.Console.WriteLine("Applying miggration...");
            context.Database.Migrate();
            if(!context.Roles.Any())
            {
                Console.WriteLine("Adding Data to Entity Role");
                context.Roles.AddRange(
                    new Role
                    {
                        RoleName = "Développeur",
                    },
                    new Role
                    {
                        RoleName = "Designer",
                    },
                    new Role
                    {
                        RoleName = "Marketeux",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
