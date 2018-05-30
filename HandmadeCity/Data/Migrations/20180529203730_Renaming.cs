using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HandmadeCity.Data.Migrations
{
    public partial class Renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Purchases_OrderId",
                table: "PurchaseProducts");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "PurchaseProducts",
                newName: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "PurchaseProducts",
                newName: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Purchases_OrderId",
                table: "PurchaseProducts",
                column: "OrderId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
