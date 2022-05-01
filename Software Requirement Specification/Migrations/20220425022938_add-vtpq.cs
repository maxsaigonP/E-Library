using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class addvtpq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaiTro_PhanQuyen_PhanQuyenId",
                table: "VaiTro");

            migrationBuilder.DropIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "PhanQuyenId",
                table: "VaiTro");

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

            migrationBuilder.CreateIndex(
                name: "IX_VaiTroPhanQuyen_PhanQuyenId",
                table: "VaiTroPhanQuyen",
                column: "PhanQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTroPhanQuyen_VaiTroId",
                table: "VaiTroPhanQuyen",
                column: "VaiTroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaiTroPhanQuyen");

            migrationBuilder.AddColumn<int>(
                name: "PhanQuyenId",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro",
                column: "PhanQuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaiTro_PhanQuyen_PhanQuyenId",
                table: "VaiTro",
                column: "PhanQuyenId",
                principalTable: "PhanQuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
