using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Library_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBorrowedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksGuid, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksGuid",
                        column: x => x.BooksGuid,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBook",
                columns: table => new
                {
                    UserGuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBook", x => new { x.UserGuid, x.BookGuid });
                    table.ForeignKey(
                        name: "FK_BorrowedBook_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BorrowedBook_Books_BookGuid",
                        column: x => x.BookGuid,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersId",
                table: "BookUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_BookGuid",
                table: "BorrowedBook",
                column: "BookGuid");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_UserId",
                table: "BorrowedBook",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "BorrowedBook");
        }
    }
}
