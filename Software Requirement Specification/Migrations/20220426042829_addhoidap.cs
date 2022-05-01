using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class addhoidap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "NguoiDung");

            migrationBuilder.CreateTable(
                name: "Hoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    TaiLieuId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hoi_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hoi_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoi_MonHocId",
                table: "Hoi",
                column: "MonHocId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hoi_NguoiDungId",
                table: "Hoi",
                column: "NguoiDungId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoi");

            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "NguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
