using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatainCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numberOfChapers",
                table: "Fluent_BookDetails",
                newName: "NoOfChapters");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "categoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "categoryId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "NoOfChapters",
                table: "Fluent_BookDetails",
                newName: "numberOfChapers");
        }
    }
}
