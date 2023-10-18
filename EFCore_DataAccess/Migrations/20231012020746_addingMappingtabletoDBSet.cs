using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingMappingtabletoDBSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_AuthorId",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_BookId",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fulent_BookAuthorMap_Fluent_Author_AuthorId",
                table: "Fulent_BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fulent_BookAuthorMap_Fluent_Book_BookId",
                table: "Fulent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fulent_BookAuthorMap",
                table: "Fulent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "Fulent_BookAuthorMap",
                newName: "Fluent_BookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "BookAuthorMap",
                newName: "BookAuthorMaps");

            migrationBuilder.RenameIndex(
                name: "IX_Fulent_BookAuthorMap_BookId",
                table: "Fluent_BookAuthorMaps",
                newName: "IX_Fluent_BookAuthorMaps_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMap_BookId",
                table: "BookAuthorMaps",
                newName: "IX_BookAuthorMaps_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMaps",
                table: "Fluent_BookAuthorMaps",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMaps",
                table: "BookAuthorMaps",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Authors_AuthorId",
                table: "BookAuthorMaps",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Books_BookId",
                table: "BookAuthorMaps",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Author_AuthorId",
                table: "Fluent_BookAuthorMaps",
                column: "AuthorId",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Book_BookId",
                table: "Fluent_BookAuthorMaps",
                column: "BookId",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Authors_AuthorId",
                table: "BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Books_BookId",
                table: "BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Author_AuthorId",
                table: "Fluent_BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Book_BookId",
                table: "Fluent_BookAuthorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMaps",
                table: "Fluent_BookAuthorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMaps",
                table: "BookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMaps",
                newName: "Fulent_BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "BookAuthorMaps",
                newName: "BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMaps_BookId",
                table: "Fulent_BookAuthorMap",
                newName: "IX_Fulent_BookAuthorMap_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMaps_BookId",
                table: "BookAuthorMap",
                newName: "IX_BookAuthorMap_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fulent_BookAuthorMap",
                table: "Fulent_BookAuthorMap",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_AuthorId",
                table: "BookAuthorMap",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_BookId",
                table: "BookAuthorMap",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fulent_BookAuthorMap_Fluent_Author_AuthorId",
                table: "Fulent_BookAuthorMap",
                column: "AuthorId",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fulent_BookAuthorMap_Fluent_Book_BookId",
                table: "Fulent_BookAuthorMap",
                column: "BookId",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
