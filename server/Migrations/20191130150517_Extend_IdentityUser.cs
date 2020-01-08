using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.Migrations
{
    public partial class Extend_IdentityUser : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "Age",
                "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Description",
                "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "UserSurname",
                "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Discriminator",
                "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Age",
                "AspNetUsers");

            migrationBuilder.DropColumn(
                "Description",
                "AspNetUsers");

            migrationBuilder.DropColumn(
                "UserSurname",
                "AspNetUsers");

            migrationBuilder.DropColumn(
                "Discriminator",
                "AspNetUsers");
        }

    }
}
