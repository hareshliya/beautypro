using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyPro.CRM.EF.Migrations
{
    public partial class _201911081222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Tbl_User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Tbl_User");
        }
    }
}
