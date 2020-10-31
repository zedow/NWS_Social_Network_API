using Microsoft.EntityFrameworkCore.Migrations;

namespace NWSocial.Migrations
{
    public partial class Initialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuildId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GuildId",
                table: "Posts",
                column: "GuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Guilds_GuildId",
                table: "Posts",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Guilds_GuildId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GuildId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GuildId",
                table: "Posts");
        }
    }
}
