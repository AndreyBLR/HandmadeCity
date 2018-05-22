using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HandmadeCity.Data.Migrations
{
    public partial class AddTopicEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TopicId",
                table: "Categories",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Topics_TopicId",
                table: "Categories",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Topics_TopicId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TopicId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Categories");
        }
    }
}
