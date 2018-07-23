using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ReworkOfPropertiesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyDescription_ItemTemplates_ItemTemplateId",
                table: "ItemPropertyDescription");

            migrationBuilder.DropIndex(
                name: "IX_ItemPropertyDescription_ItemTemplateId",
                table: "ItemPropertyDescription");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "ItemPropertyDescription");

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
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

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
                table: "ItemPropertyDescription",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyDescription_ItemTemplateId",
                table: "ItemPropertyDescription",
                column: "ItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyDescription_ItemTemplates_ItemTemplateId",
                table: "ItemPropertyDescription",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
