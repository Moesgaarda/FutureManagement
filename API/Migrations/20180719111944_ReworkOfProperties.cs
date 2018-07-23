using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ReworkOfProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProperties_Items_ItemId",
                table: "ItemProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemProperties_ItemTemplates_ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropIndex(
                name: "IX_ItemProperties_ItemId",
                table: "ItemProperties");

            migrationBuilder.DropIndex(
                name: "IX_ItemProperties_ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "ItemProperties");

            migrationBuilder.CreateTable(
                name: "ItemPropertyDescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    ItemTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPropertyDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPropertyDescription_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPropertyDescription_ItemTemplates_ItemTemplateId",
                        column: x => x.ItemTemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyDescription_ItemId",
                table: "ItemPropertyDescription",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyDescription_ItemTemplateId",
                table: "ItemPropertyDescription",
                column: "ItemTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPropertyDescription");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ItemProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
                table: "ItemProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemProperties_ItemId",
                table: "ItemProperties",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProperties_ItemTemplateId",
                table: "ItemProperties",
                column: "ItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProperties_Items_ItemId",
                table: "ItemProperties",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProperties_ItemTemplates_ItemTemplateId",
                table: "ItemProperties",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
