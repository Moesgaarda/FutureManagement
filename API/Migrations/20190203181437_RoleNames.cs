using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RoleNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleNameId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleNames", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleNameId",
                table: "AspNetUserRoles",
                column: "RoleNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_RoleNames_RoleNameId",
                table: "AspNetUserRoles",
                column: "RoleNameId",
                principalTable: "RoleNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_RoleNames_RoleNameId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "RoleNames");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleNameId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RoleNameId",
                table: "AspNetUserRoles");
        }
    }
}
