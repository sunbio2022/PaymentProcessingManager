using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentProcessingManager.Migrations
{
    public partial class DepartmentIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Users");
        }
    }
}
