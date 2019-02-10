using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RemoveEnumAndFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "ItemTemplates");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InternalOrder",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SignedById",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ItemTemplates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "ItemTemplates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemTemplateCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemplateCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderFileNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFileNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFileNames_FileData_FileDataId",
                        column: x => x.FileDataId,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFileNames_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UnitTypeId",
                table: "Projects",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AssignedUserId",
                table: "Orders",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SignedById",
                table: "Orders",
                column: "SignedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UnitTypeId",
                table: "Orders",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_CategoryId",
                table: "ItemTemplates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_UnitTypeId",
                table: "ItemTemplates",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFileNames_FileDataId",
                table: "OrderFileNames",
                column: "FileDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFileNames_OrderId",
                table: "OrderFileNames",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_ItemTemplateCategories_CategoryId",
                table: "ItemTemplates",
                column: "CategoryId",
                principalTable: "ItemTemplateCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_UnitTypes_UnitTypeId",
                table: "ItemTemplates",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AssignedUserId",
                table: "Orders",
                column: "AssignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_SignedById",
                table: "Orders",
                column: "SignedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UnitTypes_UnitTypeId",
                table: "Orders",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_StatusId",
                table: "Projects",
                column: "StatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_UnitTypes_UnitTypeId",
                table: "Projects",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_ItemTemplateCategories_CategoryId",
                table: "ItemTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_UnitTypes_UnitTypeId",
                table: "ItemTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AssignedUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_SignedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UnitTypes_UnitTypeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_StatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_UnitTypes_UnitTypeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ItemTemplateCategories");

            migrationBuilder.DropTable(
                name: "OrderFileNames");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StatusId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UnitTypeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AssignedUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SignedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UnitTypeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ItemTemplates_CategoryId",
                table: "ItemTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ItemTemplates_UnitTypeId",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InternalOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SignedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "ItemTemplates");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                table: "ItemTemplates",
                nullable: false,
                defaultValue: 0);
        }
    }
}
