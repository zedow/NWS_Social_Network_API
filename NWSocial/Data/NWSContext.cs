using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NWSocial.Data;
using NWSocial.Models;

namespace NWSocial.Data
{
    public class NWSContext : IdentityDbContext<User,Role,int>
    {
        public NWSContext(DbContextOptions<NWSContext> options) : base(options)
        {

        }

        public DbSet<Guild> Guilds { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<UserGuild> UserGuilds { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGuild>()
                .HasKey(t => new { t.UserId, t.GuildId }); ;

            modelBuilder.Entity<UserGuild>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.Guilds)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserGuild>()
                .HasOne(pt => pt.Guild)
                .WithMany(t => t.Users)
                .HasForeignKey(pt => pt.GuildId);

            modelBuilder.Entity<Post>()
                .HasOne(pt => pt.Guild)
                .WithMany(t => t.Posts)
                .HasForeignKey(pt => pt.GuildId);

            modelBuilder.Entity<Guild>()
                .HasMany(pt => pt.Posts)
                .WithOne(t => t.Guild);

            // Project to guild relation

            modelBuilder.Entity<Project>()
                .HasOne(pt => pt.Guild)
                .WithMany(p => p.Projects)
                .HasForeignKey(pt => pt.GuildId);

            // Project member relation

            modelBuilder.Entity<ProjectMember>()
                .HasKey(t => new { t.UserId, t.ProjectId }); ;

            modelBuilder.Entity<ProjectMember>()
                .HasOne(p => p.Project)
                .WithMany(pm => pm.Members)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<ProjectMember>()
                .HasOne(t => t.User)
                .WithMany(pm => pm.ProjectMembers)
                .HasForeignKey(t => t.UserId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
