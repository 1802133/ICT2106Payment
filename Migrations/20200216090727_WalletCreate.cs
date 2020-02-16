using Microsoft.EntityFrameworkCore.Migrations;

namespace ICT2106Payment.Migrations
{
    public partial class WalletCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    walletId = table.Column<string>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    walletAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.walletId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallet");
        }
    }
}
