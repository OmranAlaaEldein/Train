using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainTrain.Migrations
{
    public partial class addAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Trainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Trainers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Trainers");
        }
    }
}
