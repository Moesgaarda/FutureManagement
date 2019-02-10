using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UserRoleCategoryRelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoleCategoryRelations",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleCategoryRelations", x => new { x.UserId, x.RoleCategoryId });
                    table.ForeignKey(
                        name: "FK_UserRoleCategoryRelations_RoleCategories_RoleCategoryId",
                        column: x => x.RoleCategoryId,
                        principalTable: "RoleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleCategoryRelations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleCategoryRelations_RoleCategoryId",
                table: "UserRoleCategoryRelations",
                column: "RoleCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleCategoryRelations");
        }
    }
}
