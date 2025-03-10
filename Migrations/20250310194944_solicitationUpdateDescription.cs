using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCenterApi.Migrations
{
    /// <inheritdoc />
    public partial class solicitationUpdateDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Solicitation",
                type: "varchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Solicitation",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)");
        }
    }
}
