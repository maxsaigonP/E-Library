using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class updateTLNH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiLieu_ChuDe_ChuDeId",
                table: "TaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_ChuDeId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "ChuDeId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "TieuDe",
                table: "TaiLieu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChuDeId",
                table: "TaiLieu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TieuDe",
                table: "TaiLieu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_ChuDeId",
                table: "TaiLieu",
                column: "ChuDeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiLieu_ChuDe_ChuDeId",
                table: "TaiLieu",
                column: "ChuDeId",
                principalTable: "ChuDe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
