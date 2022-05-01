using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class dropBG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiGiang");

            migrationBuilder.RenameColumn(
                name: "TenFile",
                table: "Tep",
                newName: "TheLoai");

            migrationBuilder.RenameColumn(
                name: "LoaiFile",
                table: "Tep",
                newName: "TenTep");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySuaCuoi",
                table: "Tep",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NguoiChinhSua",
                table: "Tep",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LoaiTaiLieu",
                table: "TaiLieu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgaySuaCuoi",
                table: "Tep");

            migrationBuilder.DropColumn(
                name: "NguoiChinhSua",
                table: "Tep");

            migrationBuilder.DropColumn(
                name: "LoaiTaiLieu",
                table: "TaiLieu");

            migrationBuilder.RenameColumn(
                name: "TheLoai",
                table: "Tep",
                newName: "TenFile");

            migrationBuilder.RenameColumn(
                name: "TenTep",
                table: "Tep",
                newName: "LoaiFile");

            migrationBuilder.CreateTable(
                name: "BaiGiang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KichThuoc = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    NguoiChinhSua = table.Column<int>(type: "int", nullable: false),
                    NguoiChinhSuaCuoi = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepId = table.Column<int>(type: "int", nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiGiang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiGiang_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiGiang_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiGiang_Tep_TepId",
                        column: x => x.TepId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_MonHocId",
                table: "BaiGiang",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_NguoiDungId",
                table: "BaiGiang",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_TepId",
                table: "BaiGiang",
                column: "TepId",
                unique: true);
        }
    }
}
