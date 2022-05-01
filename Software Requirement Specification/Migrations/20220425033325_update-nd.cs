using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class updatend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gmail",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "TaiKhoan");

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "NguoiDung",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "NguoiDung");

            migrationBuilder.AddColumn<string>(
                name: "Gmail",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
