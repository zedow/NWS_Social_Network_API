using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWSocial.Migrations
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGuild_Guilds_GuildId",
                table: "UserGuild");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuild_Users_UserId",
                table: "UserGuild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGuild",
                table: "UserGuild");

            migrationBuilder.RenameTable(
                name: "UserGuild",
                newName: "UserGuilds");

            migrationBuilder.RenameIndex(
                name: "IX_UserGuild_GuildId",
                table: "UserGuilds",
                newName: "IX_UserGuilds_GuildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGuilds",
                table: "UserGuilds",
                columns: new[] { "UserId", "GuildId" });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuilds_Guilds_GuildId",
                table: "UserGuilds",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuilds_Users_UserId",
                table: "UserGuilds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGuilds_Guilds_GuildId",
                table: "UserGuilds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuilds_Users_UserId",
                table: "UserGuilds");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGuilds",
                table: "UserGuilds");

            migrationBuilder.RenameTable(
                name: "UserGuilds",
                newName: "UserGuild");

            migrationBuilder.RenameIndex(
                name: "IX_UserGuilds_GuildId",
                table: "UserGuild",
                newName: "IX_UserGuild_GuildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGuild",
                table: "UserGuild",
                columns: new[] { "UserId", "GuildId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuild_Guilds_GuildId",
                table: "UserGuild",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuild_Users_UserId",
                table: "UserGuild",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
