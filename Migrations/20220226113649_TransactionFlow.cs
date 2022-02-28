using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentProcessingManager.Migrations
{
    public partial class TransactionFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Acquisitions",
                table: "Acquisition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Authorization",
                table: "Acquisition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostPayment",
                table: "Acquisition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reconsilation",
                table: "Acquisition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Routing",
                table: "Acquisition",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acquisitions",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "Authorization",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "PostPayment",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "Reconsilation",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "Routing",
                table: "Acquisition");
        }
    }
}
