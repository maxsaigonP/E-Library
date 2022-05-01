using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class addGhiChu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "TaiLieu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThongBaoMonHoc",
                table: "MonHoc",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "ThongBaoMonHoc",
                table: "MonHoc");
        }
    }
}
