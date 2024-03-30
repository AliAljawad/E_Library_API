using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Library_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBorrowedBooks_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_UserId",
                table: "BorrowedBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBook",
                table: "BorrowedBook");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBook_UserId",
                table: "BorrowedBook");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "BorrowedBook");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BorrowedBook",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBook",
                table: "BorrowedBook",
                columns: new[] { "UserId", "BookGuid" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_UserId",
                table: "BorrowedBook",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_UserId",
                table: "BorrowedBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBook",
                table: "BorrowedBook");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BorrowedBook",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "BorrowedBook",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBook",
                table: "BorrowedBook",
                columns: new[] { "UserGuid", "BookGuid" });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_UserId",
                table: "BorrowedBook",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBook_AspNetUsers_UserId",
                table: "BorrowedBook",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
