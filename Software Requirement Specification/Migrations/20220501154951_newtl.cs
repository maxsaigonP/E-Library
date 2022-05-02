using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class newtl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_TepId",
                table: "TaiLieu");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_TepId",
                table: "TaiLieu",
                column: "TepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_TepId",
                table: "TaiLieu");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_TepId",
                table: "TaiLieu",
                column: "TepId",
                unique: true);
        }
    }
}
