using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class dropTH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_TruongHoc_TruongId",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ThuVien_TruongHoc_TruongHocId",
                table: "ThuVien");

            migrationBuilder.DropTable(
                name: "TruongHoc");

            migrationBuilder.DropIndex(
                name: "IX_ThuVien_TruongHocId",
                table: "ThuVien");

            migrationBuilder.DropIndex(
                name: "IX_LopHoc_TruongId",
                table: "LopHoc");

            migrationBuilder.DropColumn(
                name: "TruongHocId",
                table: "ThuVien");

            migrationBuilder.AddColumn<string>(
                name: "HieuTruong",
                table: "ThuVien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTruongHoc",
                table: "ThuVien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenTruongHoc",
                table: "ThuVien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "ThuVien",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HieuTruong",
                table: "ThuVien");

            migrationBuilder.DropColumn(
                name: "MaTruongHoc",
                table: "ThuVien");

            migrationBuilder.DropColumn(
                name: "TenTruongHoc",
                table: "ThuVien");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "ThuVien");

            migrationBuilder.AddColumn<int>(
                name: "TruongHocId",
                table: "ThuVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TruongHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruongHoc", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThuVien_TruongHocId",
                table: "ThuVien",
                column: "TruongHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_TruongId",
                table: "LopHoc",
                column: "TruongId");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_TruongHoc_TruongId",
                table: "LopHoc",
                column: "TruongId",
                principalTable: "TruongHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThuVien_TruongHoc_TruongHocId",
                table: "ThuVien",
                column: "TruongHocId",
                principalTable: "TruongHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
