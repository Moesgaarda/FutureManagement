using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class fixedtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplatePropertys_ItemPropertyNames_PropertyId",
                table: "TemplatePropertys");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplatePropertys_ItemTemplates_TemplateId",
                table: "TemplatePropertys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplatePropertys",
                table: "TemplatePropertys");

            migrationBuilder.RenameTable(
                name: "TemplatePropertys",
                newName: "TemplateProperties");

            migrationBuilder.RenameIndex(
                name: "IX_TemplatePropertys_PropertyId",
                table: "TemplateProperties",
                newName: "IX_TemplateProperties_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateProperties",
                table: "TemplateProperties",
                columns: new[] { "TemplateId", "PropertyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateProperties_ItemPropertyNames_PropertyId",
                table: "TemplateProperties",
                column: "PropertyId",
                principalTable: "ItemPropertyNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateProperties_ItemTemplates_TemplateId",
                table: "TemplateProperties",
                column: "TemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateProperties_ItemPropertyNames_PropertyId",
                table: "TemplateProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateProperties_ItemTemplates_TemplateId",
                table: "TemplateProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateProperties",
                table: "TemplateProperties");

            migrationBuilder.RenameTable(
                name: "TemplateProperties",
                newName: "TemplatePropertys");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateProperties_PropertyId",
                table: "TemplatePropertys",
                newName: "IX_TemplatePropertys_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplatePropertys",
                table: "TemplatePropertys",
                columns: new[] { "TemplateId", "PropertyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplatePropertys_ItemPropertyNames_PropertyId",
                table: "TemplatePropertys",
                column: "PropertyId",
                principalTable: "ItemPropertyNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplatePropertys_ItemTemplates_TemplateId",
                table: "TemplatePropertys",
                column: "TemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
