using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApi.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookloans_BookId",
                table: "Bookloans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookloans_UserId",
                table: "Bookloans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookloans_Books_BookId",
                table: "Bookloans",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookloans_Users_UserId",
                table: "Bookloans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookloans_Books_BookId",
                table: "Bookloans");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookloans_Users_UserId",
                table: "Bookloans");

            migrationBuilder.DropIndex(
                name: "IX_Bookloans_BookId",
                table: "Bookloans");

            migrationBuilder.DropIndex(
                name: "IX_Bookloans_UserId",
                table: "Bookloans");
        }
    }
}
