using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class updatedlistitemtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Listitems",
                table: "Listitems");

            migrationBuilder.DropIndex(
                name: "IX_Listitems_ItemId",
                table: "Listitems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Listitems");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Listitems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Listitems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listitems",
                table: "Listitems",
                columns: new[] { "ItemId", "ListId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Listitems",
                table: "Listitems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Listitems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Listitems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Listitems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listitems",
                table: "Listitems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listitems_ItemId",
                table: "Listitems",
                column: "ItemId");
        }
    }
}
