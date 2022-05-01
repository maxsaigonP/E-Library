using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class updatetk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_VaiTro_VaiTroId",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan_VaiTroId",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "VaiTroId",
                table: "TaiKhoan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaiTroId",
                table: "TaiKhoan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_VaiTroId",
                table: "TaiKhoan",
                column: "VaiTroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_VaiTro_VaiTroId",
                table: "TaiKhoan",
                column: "VaiTroId",
                principalTable: "VaiTro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
