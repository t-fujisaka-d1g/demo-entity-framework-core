using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class CustomizeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qrs_Books_BookId",
                table: "Qrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qrs",
                table: "Qrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Qrs",
                newName: "X002QRS");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "X001BOOKS");

            migrationBuilder.RenameIndex(
                name: "IX_Qrs_BookId",
                table: "X002QRS",
                newName: "IX_X002QRS_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_X002QRS",
                table: "X002QRS",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_X001BOOKS",
                table: "X001BOOKS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_X002QRS_X001BOOKS_BookId",
                table: "X002QRS",
                column: "BookId",
                principalTable: "X001BOOKS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_X002QRS_X001BOOKS_BookId",
                table: "X002QRS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_X002QRS",
                table: "X002QRS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_X001BOOKS",
                table: "X001BOOKS");

            migrationBuilder.RenameTable(
                name: "X002QRS",
                newName: "Qrs");

            migrationBuilder.RenameTable(
                name: "X001BOOKS",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_X002QRS_BookId",
                table: "Qrs",
                newName: "IX_Qrs_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qrs",
                table: "Qrs",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Qrs_Books_BookId",
                table: "Qrs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
