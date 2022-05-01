using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class updateM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChuDe",
                table: "ThongBao",
                newName: "LoaiThongBao");

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGian",
                table: "ThongBao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGian",
                table: "ThongBao");

            migrationBuilder.RenameColumn(
                name: "LoaiThongBao",
                table: "ThongBao",
                newName: "ChuDe");
        }
    }
}
