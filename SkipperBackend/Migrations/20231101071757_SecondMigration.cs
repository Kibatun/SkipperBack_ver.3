using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkipperBack3.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new string[] { "Id", "Key", "Name", "Subcategories" },
                values: new object[] { Guid.NewGuid(), "development", "Разработка", new string[] { "Backend", "Frontend", "Мобильная разработка", "Desktop" } }
                );
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
