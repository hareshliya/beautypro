using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyPro.CRM.EF.Migrations
{
    public partial class _201910290140 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Tbl_CustomerGiftVoucher",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Tbl_CustomerGiftVoucher",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
