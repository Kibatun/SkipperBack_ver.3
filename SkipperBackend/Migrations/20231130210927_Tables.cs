using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkipperBack3.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("15390e8a-6a77-4e11-bbea-9e26a1d667c0"));

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MentorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Desctiption = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Weekday = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: true),
                    SlotId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Post = table.Column<string>(type: "text", nullable: false),
                    About = table.Column<string>(type: "text", nullable: false),
                    Lessons = table.Column<string>(type: "text", nullable: false),
                    CvInfoId = table.Column<string>(type: "text", nullable: true),
                    Messengers = table.Column<float>(type: "real", nullable: false),
                    UpdatedAt = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CreatedAt = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MentorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LessonsCount = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ReviewersCount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MentorId = table.Column<Guid>(type: "uuid", nullable: true),
                    TagId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSLot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSLot", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Key", "Name", "Subcategories" },
                values: new object[] { new Guid("74b50990-126f-4550-b6c0-845b8643b5df"), "development", "разработка", new[] { "backend", "frontend" } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "LessonSlots");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "MentorStats");

            migrationBuilder.DropTable(
                name: "MentorTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TimeSLot");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74b50990-126f-4550-b6c0-845b8643b5df"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Key", "Name", "Subcategories" },
                values: new object[] { new Guid("15390e8a-6a77-4e11-bbea-9e26a1d667c0"), "development", "разработка", new[] { "backend", "frontend" } });
        }
    }
}
