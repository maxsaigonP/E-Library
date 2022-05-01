using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoTaiLieuChoDuyet",
                table: "MonHoc");

            migrationBuilder.AddColumn<string>(
                name: "TenDeThi",
                table: "DeThi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenDeThi",
                table: "DeThi");

            migrationBuilder.AddColumn<int>(
                name: "SoTaiLieuChoDuyet",
                table: "MonHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
