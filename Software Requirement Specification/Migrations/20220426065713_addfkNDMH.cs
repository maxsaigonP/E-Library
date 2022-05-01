using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class addfkNDMH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDungMonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungMonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDungMonHoc_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDungMonHoc_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungMonHoc_MonHocId",
                table: "NguoiDungMonHoc",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungMonHoc_NguoiDungId",
                table: "NguoiDungMonHoc",
                column: "NguoiDungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiDungMonHoc");
        }
    }
}
