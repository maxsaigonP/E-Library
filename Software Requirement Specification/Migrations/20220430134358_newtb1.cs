using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class newtb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HocVienId",
                table: "ThongBao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HocVienId",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
