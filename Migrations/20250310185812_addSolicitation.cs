using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCenterApi.Migrations
{
    /// <inheritdoc />
    public partial class addSolicitation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitation_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitation_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_RequestTypeId",
                table: "Solicitation",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_StatusId",
                table: "Solicitation",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitation");
        }
    }
}
