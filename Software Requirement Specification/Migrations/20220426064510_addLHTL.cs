using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class addLHTL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_LopHocTaiLieu_LopHocId",
                table: "LopHocTaiLieu",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocTaiLieu_TaiLieuId",
                table: "LopHocTaiLieu",
                column: "TaiLieuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LopHocTaiLieu");
        }
    }
}
