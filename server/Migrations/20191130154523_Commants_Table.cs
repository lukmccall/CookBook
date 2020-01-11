using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.Migrations
{
    public partial class Commants_Table : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Comments",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        "FK_Comments_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Comments_UserId",
                "Comments",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Comments");
        }

    }
}
