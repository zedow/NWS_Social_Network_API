using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWSocial.Migrations
{
    public partial class GuildToUserTable20 : Migration
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

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserGuilds",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isValidated",
                table: "UserGuilds",
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
