using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro");

            migrationBuilder.AddColumn<string>(
                name: "ChuDe",
                table: "ThongBao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NguoiDungId",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LopHocMonHoc",
                columns: table => new
                {
                    LopHocId = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocMonHoc", x => new { x.LopHocId, x.MonHocId });
                    table.ForeignKey(
                        name: "FK_LopHocMonHoc_LopHoc_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHocMonHoc_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro",
                column: "PhanQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocMonHoc_MonHocId",
                table: "LopHocMonHoc",
                column: "MonHocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LopHocMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "ChuDe",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "NguoiDungId",
                table: "ThongBao");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro",
                column: "PhanQuyenId",
                unique: true);
        }
    }
}
