using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PaymentProcessingManager.Migrations
{
    public partial class CustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Acquisition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRegistryID",
                table: "Acquisition",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    CustomerAccount = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Contact = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_CustomerID",
                table: "Acquisition",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_ServiceRegistryID",
                table: "Acquisition",
                column: "ServiceRegistryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Customer_CustomerID",
                table: "Acquisition",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_ServiceRegistry_ServiceRegistryID",
                table: "Acquisition",
                column: "ServiceRegistryID",
                principalTable: "ServiceRegistry",
                principalColumn: "ServiceRegistryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Customer_CustomerID",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_ServiceRegistry_ServiceRegistryID",
                table: "Acquisition");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Acquisition_CustomerID",
                table: "Acquisition");

            migrationBuilder.DropIndex(
                name: "IX_Acquisition_ServiceRegistryID",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "ServiceRegistryID",
                table: "Acquisition");
        }
    }
}
