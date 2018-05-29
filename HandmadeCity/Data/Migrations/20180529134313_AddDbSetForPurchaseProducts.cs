using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HandmadeCity.Data.Migrations
{
    public partial class AddDbSetForPurchaseProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_Purchases_OrderId",
                table: "PurchaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_Products_ProductId",
                table: "PurchaseProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseProduct",
                table: "PurchaseProduct");

            migrationBuilder.RenameTable(
                name: "PurchaseProduct",
                newName: "PurchaseProducts");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseProduct_ProductId",
                table: "PurchaseProducts",
                newName: "IX_PurchaseProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Purchases_OrderId",
                table: "PurchaseProducts",
                column: "OrderId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Products_ProductId",
                table: "PurchaseProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Purchases_OrderId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Products_ProductId",
                table: "PurchaseProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts");

            migrationBuilder.RenameTable(
                name: "PurchaseProducts",
                newName: "PurchaseProduct");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseProducts_ProductId",
                table: "PurchaseProduct",
                newName: "IX_PurchaseProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseProduct",
                table: "PurchaseProduct",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_Purchases_OrderId",
                table: "PurchaseProduct",
                column: "OrderId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_Products_ProductId",
                table: "PurchaseProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
