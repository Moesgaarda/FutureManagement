using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RemovedRevisionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RevisionID",
                table: "ItemTemplates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RevisionID",
                table: "ItemTemplates",
                nullable: false,
                defaultValue: 0);
        }
    }
}
