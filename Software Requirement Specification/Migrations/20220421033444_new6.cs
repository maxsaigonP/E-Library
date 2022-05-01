using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class new6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "TaiLieu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_LopHocId",
                table: "TaiLieu",
                column: "LopHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiLieu_LopHoc_LopHocId",
                table: "TaiLieu",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiLieu_LopHoc_LopHocId",
                table: "TaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_LopHocId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "TaiLieu");
        }
    }
}
