using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class new23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauHoi_DeThi_DeThiId",
                table: "CauHoi");

            migrationBuilder.DropIndex(
                name: "IX_CauHoi_DeThiId",
                table: "CauHoi");

            migrationBuilder.DropColumn(
                name: "DeThiId",
                table: "CauHoi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeThiId",
                table: "CauHoi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_DeThiId",
                table: "CauHoi",
                column: "DeThiId");

            migrationBuilder.AddForeignKey(
                name: "FK_CauHoi_DeThi_DeThiId",
                table: "CauHoi",
                column: "DeThiId",
                principalTable: "DeThi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
