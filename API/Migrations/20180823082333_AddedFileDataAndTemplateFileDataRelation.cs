using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedFileDataAndTemplateFileDataRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "ItemTemplates");

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileHash = table.Column<byte[]>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateFileDataRelation",
                columns: table => new
                {
                    TemplateId = table.Column<int>(nullable: false),
                    FileDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateFileDataRelation", x => new { x.TemplateId, x.FileDataId });
                    table.ForeignKey(
                        name: "FK_TemplateFileDataRelation_FileData_FileDataId",
                        column: x => x.FileDataId,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateFileDataRelation_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFileDataRelation_FileDataId",
                table: "TemplateFileDataRelation",
                column: "FileDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateFileDataRelation");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "ItemTemplates",
                nullable: true);
        }
    }
}
