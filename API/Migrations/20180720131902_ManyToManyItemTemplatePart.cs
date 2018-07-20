using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ManyToManyItemTemplatePart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_ItemTemplates_ItemTemplateId",
                table: "ItemTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ItemTemplates_ItemTemplateId",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "ItemTemplates");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ItemTemplates",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "ItemTemplateParts",
                columns: table => new
                {
                    TemplateId = table.Column<int>(nullable: false),
                    PartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemplateParts", x => new { x.TemplateId, x.PartId });
                    table.ForeignKey(
                        name: "FK_ItemTemplateParts_ItemTemplates_PartId",
                        column: x => x.PartId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTemplateParts_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplateParts_PartId",
                table: "ItemTemplateParts",
                column: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTemplateParts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ItemTemplates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
                table: "ItemTemplates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_ItemTemplateId",
                table: "ItemTemplates",
                column: "ItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_ItemTemplates_ItemTemplateId",
                table: "ItemTemplates",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
