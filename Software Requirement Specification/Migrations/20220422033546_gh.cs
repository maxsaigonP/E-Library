using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class gh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocMonHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_LopHocMonHocId1",
                table: "LopHocMonHoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LopHocMonHoc",
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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LopHocMonHoc",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LopHocMonHoc",
                table: "LopHocMonHoc",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocMonHoc_LopHocId",
                table: "LopHocMonHoc",
                column: "LopHocId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_MonHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LopHocMonHoc",
                table: "LopHocMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LopHocMonHoc_LopHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropColumn(
                name: "Id",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_LopHocMonHoc",
                table: "LopHocMonHoc",
                columns: new[] { "LopHocMonHocId", "LopHocMonHocId1" });

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
    }
}
