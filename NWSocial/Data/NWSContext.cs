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

        public DbSet<Post> Posts { get; set; }

        public DbSet<UserGuild> UserGuilds { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectSlot> ProjectSlots { get; set; }
        public DbSet<ProjectRequest> ProjectRequests { get; set; }

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
            modelBuilder.Entity<Post>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Guild>()
                .HasMany(pt => pt.Posts)
                .WithOne(t => t.Guild);

            // Project to guild relation

            modelBuilder.Entity<Project>()
                .HasOne(pt => pt.Guild)
                .WithMany(p => p.Projects)
                .HasForeignKey(pt => pt.GuildId);

            // Project slot to project relation
            modelBuilder.Entity<ProjectSlot>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectSlots)
                .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectRequest>()
                .HasKey(t => new { t.SlotId, t.UserId });

            modelBuilder.Entity<ProjectRequest>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.ProjectRequests)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<ProjectRequest>()
                .HasOne(pt => pt.ProjectSlot)
                .WithMany(p => p.ProjectRequests)
                .HasForeignKey(pt => pt.SlotId);

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

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pt => pt.Slot)
                .WithOne(p => p.ProjectMember)
                .HasForeignKey<ProjectMember>(pt => pt.SlotId);
        }
    }
}
