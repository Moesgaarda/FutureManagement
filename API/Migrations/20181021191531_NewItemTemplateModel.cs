using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewItemTemplateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ItemTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RevisionID",
                table: "ItemTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RevisionedFromId",
                table: "ItemTemplates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_RevisionedFromId",
                table: "ItemTemplates",
                column: "RevisionedFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_ItemTemplates_RevisionedFromId",
                table: "ItemTemplates",
                column: "RevisionedFromId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_ItemTemplates_RevisionedFromId",
                table: "ItemTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ItemTemplates_RevisionedFromId",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "RevisionID",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "RevisionedFromId",
                table: "ItemTemplates");
        }
    }
}
