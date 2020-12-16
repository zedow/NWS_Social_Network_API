﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NWSocial.Data;

namespace NWSocial.Migrations
{
    [DbContext(typeof(NWSContext))]
    partial class NWSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NWSocial.Models.Guild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("NWSocial.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GuildId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NWSocial.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeadLine")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("GuildId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NWSocial.Models.ProjectMember", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SlotId")
                        .IsUnique();

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("NWSocial.Models.ProjectRequest", b =>
                {
                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SlotId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectRequests");
                });

            modelBuilder.Entity("NWSocial.Models.ProjectSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSlots");
                });

            modelBuilder.Entity("NWSocial.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NWSocial.Models.UserGuild", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GuildId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "GuildId");

                    b.HasIndex("GuildId");

                    b.ToTable("UserGuilds");
                });

            modelBuilder.Entity("NWSocial.Models.Post", b =>
                {
                    b.HasOne("NWSocial.Models.Guild", "Guild")
                        .WithMany("Posts")
                        .HasForeignKey("GuildId");

                    b.HasOne("NWSocial.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NWSocial.Models.Project", b =>
                {
                    b.HasOne("NWSocial.Models.Guild", "Guild")
                        .WithMany("Projects")
                        .HasForeignKey("GuildId");
                });

            modelBuilder.Entity("NWSocial.Models.ProjectMember", b =>
                {
                    b.HasOne("NWSocial.Models.Project", "Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NWSocial.Models.ProjectSlot", "Slot")
                        .WithOne("ProjectMember")
                        .HasForeignKey("NWSocial.Models.ProjectMember", "SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NWSocial.Models.User", "User")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NWSocial.Models.ProjectRequest", b =>
                {
                    b.HasOne("NWSocial.Models.ProjectSlot", "ProjectSlot")
                        .WithMany("ProjectRequests")
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NWSocial.Models.User", "User")
                        .WithMany("ProjectRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NWSocial.Models.ProjectSlot", b =>
                {
                    b.HasOne("NWSocial.Models.Project", "Project")
                        .WithMany("ProjectSlots")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NWSocial.Models.UserGuild", b =>
                {
                    b.HasOne("NWSocial.Models.Guild", "Guild")
                        .WithMany("Users")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NWSocial.Models.User", "User")
                        .WithMany("Guilds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
