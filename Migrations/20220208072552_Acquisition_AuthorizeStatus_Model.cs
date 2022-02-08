using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PaymentProcessingManager.Migrations
{
    public partial class Acquisition_AuthorizeStatus_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizeStatus",
                columns: table => new
                {
                    AuthorizeStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AuthorizeStatusName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeStatus", x => x.AuthorizeStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateway",
                columns: table => new
                {
                    PaymentGatewayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PaymentGatewayName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateway", x => x.PaymentGatewayID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TransactionID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acquisition",
                columns: table => new
                {
                    AcquisitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TransactionID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Currency = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    AuthorizeStatusID = table.Column<int>(type: "int", nullable: true),
                    PostData = table.Column<int>(type: "int", nullable: true),
                    BURS = table.Column<string>(type: "text", nullable: true),
                    BURSNotes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisition", x => x.AcquisitionID);
                    table.ForeignKey(
                        name: "FK_Acquisition_AuthorizeStatus_AuthorizeStatusID",
                        column: x => x.AuthorizeStatusID,
                        principalTable: "AuthorizeStatus",
                        principalColumn: "AuthorizeStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRegistry",
                columns: table => new
                {
                    ServiceRegistryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PaymentGatewayID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    MerchantID = table.Column<string>(type: "text", nullable: true),
                    FolderPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRegistry", x => x.ServiceRegistryID);
                    table.ForeignKey(
                        name: "FK_ServiceRegistry_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRegistry_PaymentGateway_PaymentGatewayID",
                        column: x => x.PaymentGatewayID,
                        principalTable: "PaymentGateway",
                        principalColumn: "PaymentGatewayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_AuthorizeStatusID",
                table: "Acquisition",
                column: "AuthorizeStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_DepartmentID",
                table: "Acquisition",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRegistry_DepartmentID",
                table: "ServiceRegistry",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRegistry_PaymentGatewayID",
                table: "ServiceRegistry",
                column: "PaymentGatewayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquisition");

            migrationBuilder.DropTable(
                name: "ServiceRegistry");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "AuthorizeStatus");

            migrationBuilder.DropTable(
                name: "PaymentGateway");
        }
    }
}
