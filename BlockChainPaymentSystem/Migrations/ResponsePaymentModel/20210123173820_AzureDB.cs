using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlockChainPaymentSystem.Migrations.ResponsePaymentModel
{
    public partial class AzureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponsePaymentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pay_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price_amount = table.Column<double>(type: "float", nullable: false),
                    price_currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pay_amount = table.Column<double>(type: "float", nullable: false),
                    pay_currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actually_paid = table.Column<double>(type: "float", nullable: false),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payin_extra_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ipn_callback_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    purchase_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    outcome_amount = table.Column<double>(type: "float", nullable: false),
                    outcome_currency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsePaymentModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsePaymentModel");
        }
    }
}
