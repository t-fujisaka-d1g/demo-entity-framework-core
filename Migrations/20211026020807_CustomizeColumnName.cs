using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class CustomizeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_X002QRS_X001BOOKS_BookId",
                table: "X002QRS");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "X002QRS",
                newName: "X002URL");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "X002QRS",
                newName: "X002BOOKID_X001BOOKS");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "X002QRS",
                newName: "X002QRCODE");

            migrationBuilder.RenameIndex(
                name: "IX_X002QRS_BookId",
                table: "X002QRS",
                newName: "IX_X002QRS_X002BOOKID_X001BOOKS");

            migrationBuilder.RenameColumn(
                name: "ReleasedAt",
                table: "X001BOOKS",
                newName: "X001RELEASEAT");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "X001BOOKS",
                newName: "X001BOOKNAME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "X001BOOKS",
                newName: "X001BOOKID");

            migrationBuilder.AddForeignKey(
                name: "FK_X002QRS_X001BOOKS_X002BOOKID_X001BOOKS",
                table: "X002QRS",
                column: "X002BOOKID_X001BOOKS",
                principalTable: "X001BOOKS",
                principalColumn: "X001BOOKID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_X002QRS_X001BOOKS_X002BOOKID_X001BOOKS",
                table: "X002QRS");

            migrationBuilder.RenameColumn(
                name: "X002URL",
                table: "X002QRS",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "X002BOOKID_X001BOOKS",
                table: "X002QRS",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "X002QRCODE",
                table: "X002QRS",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_X002QRS_X002BOOKID_X001BOOKS",
                table: "X002QRS",
                newName: "IX_X002QRS_BookId");

            migrationBuilder.RenameColumn(
                name: "X001RELEASEAT",
                table: "X001BOOKS",
                newName: "ReleasedAt");

            migrationBuilder.RenameColumn(
                name: "X001BOOKNAME",
                table: "X001BOOKS",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "X001BOOKID",
                table: "X001BOOKS",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_X002QRS_X001BOOKS_BookId",
                table: "X002QRS",
                column: "BookId",
                principalTable: "X001BOOKS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
