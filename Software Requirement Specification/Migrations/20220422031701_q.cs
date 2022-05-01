using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_MonHocId",
                table: "LopHocMonHoc");

            migrationBuilder.RenameColumn(
                name: "MonHocId",
                table: "LopHocMonHoc",
                newName: "LopHocMonHocId1");

            migrationBuilder.RenameColumn(
                name: "LopHocId",
                table: "LopHocMonHoc",
                newName: "LopHocMonHocId");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocMonHoc_MonHocId",
                table: "LopHocMonHoc",
                newName: "IX_LopHocMonHoc_LopHocMonHocId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocMonHocId",
                table: "LopHocMonHoc",
                column: "LopHocMonHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_LopHocMonHocId1",
                table: "LopHocMonHoc",
                column: "LopHocMonHocId1",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocMonHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_LopHocMonHocId1",
                table: "LopHocMonHoc");

            migrationBuilder.RenameColumn(
                name: "LopHocMonHocId1",
                table: "LopHocMonHoc",
                newName: "MonHocId");

            migrationBuilder.RenameColumn(
                name: "LopHocMonHocId",
                table: "LopHocMonHoc",
                newName: "LopHocId");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocMonHoc_LopHocMonHocId1",
                table: "LopHocMonHoc",
                newName: "IX_LopHocMonHoc_MonHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocId",
                table: "LopHocMonHoc",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_MonHocId",
                table: "LopHocMonHoc",
                column: "MonHocId",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
