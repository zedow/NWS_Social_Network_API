using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWSocial.Migrations
{
    public partial class UserGuild_Table_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGuilds",
                table: "UserGuilds");

            migrationBuilder.DropIndex(
                name: "IX_UserGuilds_UserId",
                table: "UserGuilds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGuilds");

            migrationBuilder.DropColumn(
                name: "isValidated",
                table: "UserGuilds");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserGuilds",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGuilds",
                table: "UserGuilds",
                columns: new[] { "UserId", "GuildId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGuilds",
                table: "UserGuilds");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserGuilds");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserGuilds",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isValidated",
                table: "UserGuilds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGuilds",
                table: "UserGuilds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuilds_UserId",
                table: "UserGuilds",
                column: "UserId");
        }
    }
}
