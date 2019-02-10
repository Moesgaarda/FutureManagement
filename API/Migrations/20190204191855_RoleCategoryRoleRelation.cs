using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RoleCategoryRoleRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleCategoryRoleRelation",
                columns: table => new
                {
                    RoleCategoryId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleCategoryRoleRelation", x => new { x.RoleCategoryId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleCategoryRoleRelation_RoleCategories_RoleCategoryId",
                        column: x => x.RoleCategoryId,
                        principalTable: "RoleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleCategoryRoleRelation_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleCategoryRoleRelation_RoleId",
                table: "RoleCategoryRoleRelation",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleCategoryRoleRelation");

            migrationBuilder.DropTable(
                name: "RoleCategories");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetRoles");

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
    }
}
