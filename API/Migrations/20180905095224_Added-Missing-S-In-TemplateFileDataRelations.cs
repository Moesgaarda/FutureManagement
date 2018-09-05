using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedMissingSInTemplateFileDataRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateFileDataRelation_FileData_FileDataId",
                table: "TemplateFileDataRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateFileDataRelation_ItemTemplates_TemplateId",
                table: "TemplateFileDataRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateFileDataRelation",
                table: "TemplateFileDataRelation");

            migrationBuilder.RenameTable(
                name: "TemplateFileDataRelation",
                newName: "TemplateFileDataRelations");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateFileDataRelation_FileDataId",
                table: "TemplateFileDataRelations",
                newName: "IX_TemplateFileDataRelations_FileDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateFileDataRelations",
                table: "TemplateFileDataRelations",
                columns: new[] { "TemplateId", "FileDataId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateFileDataRelations_FileData_FileDataId",
                table: "TemplateFileDataRelations",
                column: "FileDataId",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateFileDataRelations_ItemTemplates_TemplateId",
                table: "TemplateFileDataRelations",
                column: "TemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateFileDataRelations_FileData_FileDataId",
                table: "TemplateFileDataRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateFileDataRelations_ItemTemplates_TemplateId",
                table: "TemplateFileDataRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateFileDataRelations",
                table: "TemplateFileDataRelations");

            migrationBuilder.RenameTable(
                name: "TemplateFileDataRelations",
                newName: "TemplateFileDataRelation");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateFileDataRelations_FileDataId",
                table: "TemplateFileDataRelation",
                newName: "IX_TemplateFileDataRelation_FileDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateFileDataRelation",
                table: "TemplateFileDataRelation",
                columns: new[] { "TemplateId", "FileDataId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateFileDataRelation_FileData_FileDataId",
                table: "TemplateFileDataRelation",
                column: "FileDataId",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateFileDataRelation_ItemTemplates_TemplateId",
                table: "TemplateFileDataRelation",
                column: "TemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
