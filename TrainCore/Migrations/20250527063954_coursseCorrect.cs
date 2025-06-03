using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainTrain.Migrations
{
    public partial class coursseCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "end_time",
                table: "Courses",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_date",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "start_time",
                table: "Courses",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_date",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "end_time",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "start_time",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
