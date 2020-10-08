using Microsoft.EntityFrameworkCore;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Data
{
    public class NWSContext : DbContext
    {
        public NWSContext(DbContextOptions<NWSContext> options) : base(options)
        {

        }

        public DbSet<Guild> Guilds { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserGuild> UserGuilds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGuild>()
                .HasKey(t => new { t.UserId, t.GuildId });

            modelBuilder.Entity<UserGuild>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserGuilds)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserGuild>()
                .HasOne(pt => pt.Guild)
                .WithMany(t => t.UserGuilds)
                .HasForeignKey(pt => pt.GuildId);
        }
    }
}
