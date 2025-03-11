using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCenterApi.Migrations
{
    /// <inheritdoc />
    public partial class addIndexSolicitation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Solicitation_StatusId",
                table: "Solicitation",
                newName: "IX_StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentId",
                table: "Solicitation",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentId",
                table: "Solicitation");

            migrationBuilder.RenameIndex(
                name: "IX_StatusId",
                table: "Solicitation",
                newName: "IX_Solicitation_StatusId");
        }
    }
}
