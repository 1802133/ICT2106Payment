using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICT2106Payment.Migrations
{
    public partial class InitialWalletCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletTransaction",
                columns: table => new
                {
                    walletTransactionId = table.Column<string>(nullable: false),
                    walletId = table.Column<string>(nullable: true),
                    transactionType = table.Column<string>(nullable: true),
                    transactionAmount = table.Column<decimal>(nullable: false),
                    transactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransaction", x => x.walletTransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletTransaction");
        }
    }
}
