using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addedTemplateProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProperties_ItemTemplates_ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyDescription_Items_ItemId",
                table: "ItemPropertyDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPropertyDescription",
                table: "ItemPropertyDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemProperties",
                table: "ItemProperties");

            migrationBuilder.DropIndex(
                name: "IX_ItemProperties_ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.RenameTable(
                name: "ItemPropertyDescription",
                newName: "ItemPropertyDescriptions");

            migrationBuilder.RenameTable(
                name: "ItemProperties",
                newName: "ItemPropertyNames");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPropertyDescription_ItemId",
                table: "ItemPropertyDescriptions",
                newName: "IX_ItemPropertyDescriptions_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPropertyDescriptions",
                table: "ItemPropertyDescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPropertyNames",
                table: "ItemPropertyNames",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TemplatePropertys",
                columns: table => new
                {
                    TemplateId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatePropertys", x => new { x.TemplateId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_TemplatePropertys_ItemPropertyNames_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "ItemPropertyNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplatePropertys_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePropertys_PropertyId",
                table: "TemplatePropertys",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyDescriptions_Items_ItemId",
                table: "ItemPropertyDescriptions",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyDescriptions_Items_ItemId",
                table: "ItemPropertyDescriptions");

            migrationBuilder.DropTable(
                name: "TemplatePropertys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPropertyNames",
                table: "ItemPropertyNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPropertyDescriptions",
                table: "ItemPropertyDescriptions");

            migrationBuilder.RenameTable(
                name: "ItemPropertyNames",
                newName: "ItemProperties");

            migrationBuilder.RenameTable(
                name: "ItemPropertyDescriptions",
                newName: "ItemPropertyDescription");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPropertyDescriptions_ItemId",
                table: "ItemPropertyDescription",
                newName: "IX_ItemPropertyDescription_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
                table: "ItemProperties",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemProperties",
                table: "ItemProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPropertyDescription",
                table: "ItemPropertyDescription",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyDescription_Items_ItemId",
                table: "ItemPropertyDescription",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
