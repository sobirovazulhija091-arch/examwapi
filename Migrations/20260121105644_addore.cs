using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApi.Migrations
{
    /// <inheritdoc />
    public partial class addore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FullName",
                table: "Users",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Nameprofile",
                table: "Profiles",
                column: "Nameprofile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FullName",
                table: "Authors",
                column: "FullName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FullName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_Nameprofile",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Authors_FullName",
                table: "Authors");
        }
    }
}
