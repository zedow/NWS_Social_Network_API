using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWSocial.Migrations
{
    public partial class ProjectRequestandStuffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ProjectMembers");

            migrationBuilder.AddColumn<int>(
                name: "SlotId",
                table: "ProjectMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectSlots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(maxLength: 255, nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSlots_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRequests",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SlotId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequests", x => new { x.SlotId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectRequests_ProjectSlots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "ProjectSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_SlotId",
                table: "ProjectMembers",
                column: "SlotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequests_UserId",
                table: "ProjectRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSlots_ProjectId",
                table: "ProjectSlots",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_ProjectSlots_SlotId",
                table: "ProjectMembers",
                column: "SlotId",
                principalTable: "ProjectSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_ProjectSlots_SlotId",
                table: "ProjectMembers");

            migrationBuilder.DropTable(
                name: "ProjectRequests");

            migrationBuilder.DropTable(
                name: "ProjectSlots");

            migrationBuilder.DropIndex(
                name: "IX_ProjectMembers_SlotId",
                table: "ProjectMembers");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "ProjectMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ProjectMembers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
