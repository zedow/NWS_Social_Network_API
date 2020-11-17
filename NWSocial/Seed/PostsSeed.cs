using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Seed
{
    public class PostsSeed : IDbsetSeed
    {
        public void Seed(NWSContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Id = 1,
                        Title = "Random post 1",
                        Text = "Random text of post 1",
                        GuildId = null,
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Random post 2",
                        Text = "Random text of post 2",
                        GuildId = 1,
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 3,
                        Title = "Random post 3",
                        Text = "Random text of post 3",
                        GuildId = 1,
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 4,
                        Title = "Random post 4",
                        Text = "Random text of post 4",
                        GuildId = 1,
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 5,
                        Title = "Random post 5",
                        Text = "Random text of post 5",
                        GuildId = null,
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 6,
                        Title = "Random post 6",
                        Text = "Random text of post 6",
                        GuildId = null,
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 7,
                        Title = "Random post 7",
                        Text = "Random text of post 7",
                        GuildId = 2,
                        UserId = 1
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not seeding Posts...Remove current data from database to launch seeding");
            }
        }
    }
}
