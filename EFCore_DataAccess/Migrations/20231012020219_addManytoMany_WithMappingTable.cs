using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addManytoMany_WithMappingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fulent_BookAuthorMap",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fulent_BookAuthorMap", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_Fulent_BookAuthorMap_Fluent_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fulent_BookAuthorMap_Fluent_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Fluent_Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fulent_BookAuthorMap_BookId",
                table: "Fulent_BookAuthorMap",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fulent_BookAuthorMap");
        }
    }
}
