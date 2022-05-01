using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class newa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChuDeId",
                table: "TaiLieu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_ChuDeId",
                table: "TaiLieu",
                column: "ChuDeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiLieu_ChuDe_ChuDeId",
                table: "TaiLieu",
                column: "ChuDeId",
                principalTable: "ChuDe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiLieu_ChuDe_ChuDeId",
                table: "TaiLieu");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_ChuDeId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "ChuDeId",
                table: "TaiLieu");
        }
    }
}
