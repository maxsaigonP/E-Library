using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaiTro_LopHoc_LopHocId",
                table: "VaiTro");

            migrationBuilder.DropIndex(
                name: "IX_VaiTro_LopHocId",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "VaiTro");

            migrationBuilder.AlterColumn<int>(
                name: "ThongBao",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "NguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "NguoiDung");

            migrationBuilder.AlterColumn<string>(
                name: "ThongBao",
                table: "VaiTro",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_LopHocId",
                table: "VaiTro",
                column: "LopHocId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VaiTro_LopHoc_LopHocId",
                table: "VaiTro",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
