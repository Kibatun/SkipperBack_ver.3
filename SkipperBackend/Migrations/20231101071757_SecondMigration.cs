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
                values: new object[,]
                {
                    { Guid.NewGuid(), "development", "Разработка", new string[] { "Backend", "Frontend", "Мобильная разработка", "Desktop" } },
                    { Guid.NewGuid(), "analytics", "Аналитика", new string[] { "Бизнес-аналитика", "Системная аналитика" } },
                    { Guid.NewGuid(), "infrastructure", "Инфраструктура", new string[] { "DevOps", "Сетевое обеспечение", "Техподдержка" } },
                    { Guid.NewGuid(), "qa", "Тестирование", new string[] { "Ручное тестирование", "Автотестирование" } },
                    { Guid.NewGuid(), "ui_design", "Дизайн", new string[] { "Мобильный дизайн", "Принципы UI/UX", "Web-дизайн" } },
                    { Guid.NewGuid(), "design", "Проектирование", new string[] { "Проектирование систем", "Highload", "Бизнес-проектирование" } },
                    { Guid.NewGuid(), "architecture", "Программная архитектура", new string[] { "Мобильная архитектура", "Архитектура Web-приложений", "Архитектура Backend" } },
                    { Guid.NewGuid(), "management", "Менеджмент", new string[] { "Продуктовый менеджмент", "Проектный менеджмент" } },
                    { Guid.NewGuid(), "system_programming", "Системное программирование", new string[] { "Linux", "Автоматизация систем" } },
                    { Guid.NewGuid(), "sre", "Мониторинг надежности", new string[] { "SRE", "Инфраструктурный мониторинг" } },
                    { Guid.NewGuid(), "security", "Информационная безопасность", new string[] { "OWASP", "Сетевая безопасность", "Инфраструктурная безопасность" } },
                   { Guid.NewGuid(), "database", "Базы данных", new string[] { "SQL", "NoSQL", "Проектирование БД" } },
                   { Guid.NewGuid(), "data_analysis", "Анализ данных", new string[] { "Математический анализ", "Нейронные сети" } },
                   { Guid.NewGuid(), "machine_learning", "Машинное обучение", new string[] { "Распознавание образов", "Глубокое обучение", "Обучение с подкреплением", "Обработка естественного языка" } }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}