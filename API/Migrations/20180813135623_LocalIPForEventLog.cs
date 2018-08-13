using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class LocalIPForEventLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalIP",
                table: "EventLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalIP",
                table: "EventLogs");
        }
    }
}
