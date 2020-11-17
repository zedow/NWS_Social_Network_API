﻿using System;
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
            if (!context.Guilds.Any())
            {
                Console.WriteLine("Adding Data to Entity Role");
                context.Guilds.AddRange(
                    new Guild
                    {
                        Name = "Random guild 1",
                        Description = "Random description of guild 1"
                    },
                    new Guild
                    {
                        Name = "Random guild 2",
                        Description = "Random description of guild 2"
                    },
                    new Guild
                    {
                        Name = "Random guild 3",
                        Description = "Random description of guild 3"
                    },
                    new Guild
                    {
                        Name = "Random guild 4",
                        Description = "Random description of guild 4"
                    },
                    new Guild
                    {
                        Name = "Random guild 5",
                        Description = "Random description of guild 5"
                    },
                    new Guild
                    {
                        Name = "Random guild 6",
                        Description = "Random description of guild 6"
                    },
                    new Guild
                    {
                        Name = "Random guild 7",
                        Description = "Random description of guild 7"
                    }
                );
            }
            if(!context.Users.Any())
            {
                context.Users.Add(new User { Name = "User test" });
                context.SaveChanges();
            }
            if(!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "Random post 1",
                        Text = "Random text of post 1",
                        GuildId = null,
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Random post 2",
                        Text = "Random text of post 2",
                        GuildId = 1,
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Random post 3",
                        Text = "Random text of post 3",
                        GuildId = 1,
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Random post 4",
                        Text = "Random text of post 4",
                        GuildId = 1,
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Random post 5",
                        Text = "Random text of post 5",
                        GuildId = null,
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Random post 6",
                        Text = "Random text of post 6",
                        GuildId = null,
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Random post 7",
                        Text = "Random text of post 7",
                        GuildId = 2,
                        UserId = 1
                    }
                );
                context.SaveChanges();
            }
            if(!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Id = 1,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        isClosed = false,
                        GuildId = null
                    },
                    new Project
                    {
                        Id = 2,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        isClosed = false,
                        GuildId = 1
                    },
                    new Project
                    {
                        Id = 3,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        isClosed = false,
                        GuildId = 1
                    },
                    new Project
                    {
                        Id = 4,
                        Name = "Random project",
                        Description = "Random description of random project",
                        DeadLine = new DateTime(),
                        Date = new DateTime(),
                        isClosed = false,
                        GuildId = null
                    }
                );
                context.SaveChanges();
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
            }
            context.SaveChanges();
        }
    }
}
