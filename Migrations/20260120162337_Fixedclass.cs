using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApi.Migrations
{
    /// <inheritdoc />
    public partial class Fixedclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookloans_Users_UserId",
                table: "Bookloans");

            migrationBuilder.DropIndex(
                name: "IX_Bookloans_UserId",
                table: "Bookloans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookloans_UserId",
                table: "Bookloans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookloans_Users_UserId",
                table: "Bookloans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
