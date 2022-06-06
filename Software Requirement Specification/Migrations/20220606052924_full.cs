using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Requirement_Specification.Migrations
{
    public partial class full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaiTroId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoMon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiCauHoi = table.Column<int>(type: "int", nullable: false),
                    DoKho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhanQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiChinhSua = table.Column<int>(type: "int", nullable: false),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KichThuoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThacMac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThacMac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThacMac_AspNetUsers_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiThongBao = table.Column<bool>(type: "bit", nullable: false),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    HocVienId = table.Column<int>(type: "int", nullable: true),
                    DoiTuong = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenHeThong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiTruyCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgonNguXacDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NienKhoaMacDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaiNguyen = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThongBao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoMonId = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    ThongBaoMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon_BoMonId",
                        column: x => x.BoMonId,
                        principalTable: "BoMon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DapAn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoiId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dung = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DapAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DapAn_CauHoi_CauHoiId",
                        column: x => x.CauHoiId,
                        principalTable: "CauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaiTroPhanQuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaiTroId = table.Column<int>(type: "int", nullable: false),
                    PhanQuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTroPhanQuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaiTroPhanQuyen_PhanQuyen_PhanQuyenId",
                        column: x => x.PhanQuyenId,
                        principalTable: "PhanQuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaiTroPhanQuyen_VaiTro_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDeThi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TepId = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoiPheDuyet = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThi_AspNetUsers_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeThi_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeThi_Tep_TepId",
                        column: x => x.TepId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    TaiLieuId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hoi_AspNetUsers_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hoi_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocMonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopHocId = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocMonHoc", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "TaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TepId = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiChinhSuaCuoi = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NgayGuiPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiLieu_AspNetUsers_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiLieu_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiLieu_Tep_TepId",
                        column: x => x.TepId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocTaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopHocId = table.Column<int>(type: "int", nullable: false),
                    TaiLieuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocTaiLieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocTaiLieu_LopHoc_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHocTaiLieu_TaiLieu_TaiLieuId",
                        column: x => x.TaiLieuId,
                        principalTable: "TaiLieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VaiTroId",
                table: "AspNetUsers",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_DapAn_CauHoiId",
                table: "DapAn",
                column: "CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_MonHocId",
                table: "DeThi",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_TaiKhoanId",
                table: "DeThi",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_TepId",
                table: "DeThi",
                column: "TepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hoi_MonHocId",
                table: "Hoi",
                column: "MonHocId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hoi_TaiKhoanId",
                table: "Hoi",
                column: "TaiKhoanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocMonHoc_LopHocId",
                table: "LopHocMonHoc",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocMonHoc_MonHocId",
                table: "LopHocMonHoc",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocTaiLieu_LopHocId",
                table: "LopHocTaiLieu",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocTaiLieu_TaiLieuId",
                table: "LopHocTaiLieu",
                column: "TaiLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc",
                column: "BoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_MonHocId",
                table: "TaiLieu",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_TaiKhoanId",
                table: "TaiLieu",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_TepId",
                table: "TaiLieu",
                column: "TepId");

            migrationBuilder.CreateIndex(
                name: "IX_ThacMac_TaiKhoanId",
                table: "ThacMac",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTroPhanQuyen_PhanQuyenId",
                table: "VaiTroPhanQuyen",
                column: "PhanQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTroPhanQuyen_VaiTroId",
                table: "VaiTroPhanQuyen",
                column: "VaiTroId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VaiTro_VaiTroId",
                table: "AspNetUsers",
                column: "VaiTroId",
                principalTable: "VaiTro",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VaiTro_VaiTroId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropTable(
                name: "DapAn");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "Hoi");

            migrationBuilder.DropTable(
                name: "LopHocMonHoc");

            migrationBuilder.DropTable(
                name: "LopHocTaiLieu");

            migrationBuilder.DropTable(
                name: "ThacMac");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThuVien");

            migrationBuilder.DropTable(
                name: "VaiTroPhanQuyen");

            migrationBuilder.DropTable(
                name: "CauHoi");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "TaiLieu");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "Tep");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VaiTroId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VaiTroId",
                table: "AspNetUsers");
        }
    }
}
