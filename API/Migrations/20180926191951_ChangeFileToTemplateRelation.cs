using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChangeFileToTemplateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateFileDataRelations");

            migrationBuilder.CreateTable(
                name: "TemplateFileNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(nullable: true),
                    ItemTemplateId = table.Column<int>(nullable: true),
                    FileDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateFileNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateFileNames_FileData_FileDataId",
                        column: x => x.FileDataId,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateFileNames_ItemTemplates_ItemTemplateId",
                        column: x => x.ItemTemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFileNames_FileDataId",
                table: "TemplateFileNames",
                column: "FileDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFileNames_ItemTemplateId",
                table: "TemplateFileNames",
                column: "ItemTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateFileNames");

            migrationBuilder.CreateTable(
                name: "TemplateFileDataRelations",
                columns: table => new
                {
                    TemplateId = table.Column<int>(nullable: false),
                    FileDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateFileDataRelations", x => new { x.TemplateId, x.FileDataId });
                    table.ForeignKey(
                        name: "FK_TemplateFileDataRelations_FileData_FileDataId",
                        column: x => x.FileDataId,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateFileDataRelations_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFileDataRelations_FileDataId",
                table: "TemplateFileDataRelations",
                column: "FileDataId");
        }
    }
}
