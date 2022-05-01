using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class cauhoidapan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiCauHoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DapAn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoiId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_DapAn_CauHoiId",
                table: "DapAn",
                column: "CauHoiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DapAn");

            migrationBuilder.DropTable(
                name: "CauHoi");
        }
    }
}
