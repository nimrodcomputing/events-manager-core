using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsManager.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "ntext", maxLength: 100, nullable: true),
                    Abstract = table.Column<string>(type: "ntext", nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PublicationStatus = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Duration = table.Column<int>(nullable: true),
                    EventId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Abstract = table.Column<string>(nullable: true),
                    Speaker = table.Column<string>(maxLength: 50, nullable: true),
                    Moderator = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_EventId",
                table: "Session",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
