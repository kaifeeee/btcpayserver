using Microsoft.EntityFrameworkCore.Migrations;
using System;
using BTCPayServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BTCPayServer.Migrations
{
    
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211018070441_AddPayoutDestinationId")]
    public partial class AddPayoutDestinationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payouts_Destination",
                table: "Payouts");

            migrationBuilder.AddColumn<string>(
                name: "DestinationId",
                table: "Payouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_Destination",
                table: "Payouts",
                column: "Destination");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_DestinationId_State",
                table: "Payouts",
                columns: new[] { "DestinationId", "State" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payouts_Destination",
                table: "Payouts");

            migrationBuilder.DropIndex(
                name: "IX_Payouts_DestinationId_State",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Payouts");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_Destination",
                table: "Payouts",
                column: "Destination",
                unique: true);
        }
    }
}
