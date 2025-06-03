using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainTrain.Migrations
{
    public partial class buildDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activeusers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    cvpath = table.Column<string>(nullable: true),
                    specialization = table.Column<string>(nullable: true),
                    rool = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activeusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    company = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    requirements = table.Column<string>(nullable: true),
                    specialization = table.Column<string>(nullable: true),
                    salaryRange = table.Column<string>(nullable: true),
                    jobType = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    experience_level = table.Column<string>(nullable: true),
                    expirydate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    bio = table.Column<string>(nullable: true),
                    specialization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    submission_date = table.Column<DateTime>(nullable: false),
                    ActiveUser_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Activeusers_ActiveUser_id",
                        column: x => x.ActiveUser_id,
                        principalTable: "Activeusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    duration = table.Column<string>(nullable: true),
                    work_day = table.Column<string>(nullable: true),
                    reg_start_date = table.Column<DateTime>(nullable: false),
                    reg_end_date = table.Column<DateTime>(nullable: false),
                    Trainer_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Trainers_Trainer_id",
                        column: x => x.Trainer_id,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courseregistrations",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    registration_date = table.Column<DateTime>(nullable: false),
                    submission_date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    Course_id = table.Column<Guid>(nullable: false),
                    activeuser_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courseregistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courseregistrations_Courses_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courseregistrations_Activeusers_activeuser_id",
                        column: x => x.activeuser_id,
                        principalTable: "Activeusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courseregistrations_Course_id",
                table: "Courseregistrations",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Courseregistrations_activeuser_id",
                table: "Courseregistrations",
                column: "activeuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Trainer_id",
                table: "Courses",
                column: "Trainer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ActiveUser_id",
                table: "Suggestions",
                column: "ActiveUser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Courseregistrations");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Activeusers");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
