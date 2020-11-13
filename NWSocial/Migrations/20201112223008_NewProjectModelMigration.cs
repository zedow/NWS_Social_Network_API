using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWSocial.Migrations
{
<<<<<<< HEAD:NWSocial/Migrations/20201112165732_FirstMigration.cs
    public partial class FirstMigration : Migration
=======
    public partial class NewProjectModelMigration : Migration
>>>>>>> 99fa8adf2ec66c85760730da27095616199f2040:NWSocial/Migrations/20201112223008_NewProjectModelMigration.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
<<<<<<< HEAD:NWSocial/Migrations/20201112165732_FirstMigration.cs
=======
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
>>>>>>> 99fa8adf2ec66c85760730da27095616199f2040:NWSocial/Migrations/20201112223008_NewProjectModelMigration.cs
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
<<<<<<< HEAD:NWSocial/Migrations/20201112165732_FirstMigration.cs
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GoogleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
=======
                    Title = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    GuildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
>>>>>>> 99fa8adf2ec66c85760730da27095616199f2040:NWSocial/Migrations/20201112223008_NewProjectModelMigration.cs
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
<<<<<<< HEAD:NWSocial/Migrations/20201112165732_FirstMigration.cs
                    Title = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
=======
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isClosed = table.Column<bool>(nullable: false),
>>>>>>> 99fa8adf2ec66c85760730da27095616199f2040:NWSocial/Migrations/20201112223008_NewProjectModelMigration.cs
                    GuildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
<<<<<<< HEAD:NWSocial/Migrations/20201112165732_FirstMigration.cs
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Guilds_GuildId",
=======
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Guilds_GuildId",
>>>>>>> 99fa8adf2ec66c85760730da27095616199f2040:NWSocial/Migrations/20201112223008_NewProjectModelMigration.cs
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGuilds",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GuildId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGuilds", x => new { x.UserId, x.GuildId });
                    table.ForeignKey(
                        name: "FK_UserGuilds_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGuilds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMembers",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMembers", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GuildId",
                table: "Posts",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_ProjectId",
                table: "ProjectMembers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GuildId",
                table: "Projects",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GuildId",
                table: "Posts",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuilds_GuildId",
                table: "UserGuilds",
                column: "GuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProjectMembers");

            migrationBuilder.DropTable(
                name: "UserGuilds");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Guilds");
        }
    }
}
