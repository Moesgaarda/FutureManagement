using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class IsArchivedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerType_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyCategory_ItemTemplates_ItemTemplateId",
                table: "ItemPropertyCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPropertyCategory",
                table: "ItemPropertyCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerType",
                table: "CustomerType");

            migrationBuilder.RenameTable(
                name: "ItemPropertyCategory",
                newName: "ItemPropertyCategories");

            migrationBuilder.RenameTable(
                name: "CustomerType",
                newName: "CustomerTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPropertyCategory_ItemTemplateId",
                table: "ItemPropertyCategories",
                newName: "IX_ItemPropertyCategories_ItemTemplateId");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPropertyCategories",
                table: "ItemPropertyCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerTypes",
                table: "CustomerTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyCategories_ItemTemplates_ItemTemplateId",
                table: "ItemPropertyCategories",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyCategories_ItemTemplates_ItemTemplateId",
                table: "ItemPropertyCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPropertyCategories",
                table: "ItemPropertyCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerTypes",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "ItemPropertyCategories",
                newName: "ItemPropertyCategory");

            migrationBuilder.RenameTable(
                name: "CustomerTypes",
                newName: "CustomerType");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPropertyCategories_ItemTemplateId",
                table: "ItemPropertyCategory",
                newName: "IX_ItemPropertyCategory_ItemTemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPropertyCategory",
                table: "ItemPropertyCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerType",
                table: "CustomerType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerType_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyCategory_ItemTemplates_ItemTemplateId",
                table: "ItemPropertyCategory",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
