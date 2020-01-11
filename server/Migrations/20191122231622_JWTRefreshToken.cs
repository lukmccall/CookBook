using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.Migrations
{
    public partial class JWTRefreshToken : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "RefreshTokens",
                table => new
                {
                    Token = table.Column<string>(),
                    JwtId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(),
                    ExpiryDate = table.Column<DateTime>(),
                    Used = table.Column<bool>(),
                    Invalidated = table.Column<bool>(),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        "FK_RefreshTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_RefreshTokens_UserId",
                "RefreshTokens",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "RefreshTokens");
        }

    }
}
