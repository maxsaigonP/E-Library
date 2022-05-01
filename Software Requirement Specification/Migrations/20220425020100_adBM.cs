using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class adBM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeThiId",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "TepRiengTu",
                table: "VaiTro");

            migrationBuilder.AddColumn<int>(
                name: "BoMonId",
                table: "MonHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoMon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc",
                column: "BoMonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_BoMon_BoMonId",
                table: "MonHoc",
                column: "BoMonId",
                principalTable: "BoMon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_BoMon_BoMonId",
                table: "MonHoc");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "BoMonId",
                table: "MonHoc");

            migrationBuilder.AddColumn<int>(
                name: "DeThiId",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TepRiengTu",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
