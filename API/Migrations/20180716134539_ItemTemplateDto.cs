using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ItemTemplateDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "ItemTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "ItemTemplates");
        }
    }
}
