using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class updateTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "ThongBao");
        }
    }
}
