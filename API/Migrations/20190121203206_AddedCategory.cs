using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_ItemTemplateCategories_CategoryId",
                table: "ItemTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTemplateCategories",
                table: "ItemTemplateCategories");

            migrationBuilder.RenameTable(
                name: "ItemTemplateCategories",
                newName: "ItemTemplateCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTemplateCategory",
                table: "ItemTemplateCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_ItemTemplateCategory_CategoryId",
                table: "ItemTemplates",
                column: "CategoryId",
                principalTable: "ItemTemplateCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_ItemTemplateCategory_CategoryId",
                table: "ItemTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTemplateCategory",
                table: "ItemTemplateCategory");

            migrationBuilder.RenameTable(
                name: "ItemTemplateCategory",
                newName: "ItemTemplateCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTemplateCategories",
                table: "ItemTemplateCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_ItemTemplateCategories_CategoryId",
                table: "ItemTemplates",
                column: "CategoryId",
                principalTable: "ItemTemplateCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
