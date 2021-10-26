using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class CustomizeColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "X001BOOKNAME",
                table: "X001BOOKS",
                type: "nvarchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "X001BOOKNAME",
                table: "X001BOOKS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)");
        }
    }
}
