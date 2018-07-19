using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedPropertyDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPropertyCategories");

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
                table: "ItemProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemProperties_ItemTemplateId",
                table: "ItemProperties",
                column: "ItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProperties_ItemTemplates_ItemTemplateId",
                table: "ItemProperties",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProperties_ItemTemplates_ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropIndex(
                name: "IX_ItemProperties_ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemProperties");

            migrationBuilder.CreateTable(
                name: "ItemPropertyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemTemplateId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPropertyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPropertyCategories_ItemTemplates_ItemTemplateId",
                        column: x => x.ItemTemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyCategories_ItemTemplateId",
                table: "ItemPropertyCategories",
                column: "ItemTemplateId");
        }
    }
}
