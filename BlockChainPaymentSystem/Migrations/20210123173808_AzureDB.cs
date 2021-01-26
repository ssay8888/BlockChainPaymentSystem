using Microsoft.EntityFrameworkCore.Migrations;

namespace BlockChainPaymentSystem.Migrations
{
    public partial class AzureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestPaymentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price_amount = table.Column<double>(type: "float", nullable: false),
                    price_currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pay_amount = table.Column<double>(type: "float", nullable: true),
                    pay_currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ipn_callback_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fixed_rate = table.Column<bool>(type: "bit", nullable: false),
                    Case = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPaymentModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPaymentModel");
        }
    }
}
