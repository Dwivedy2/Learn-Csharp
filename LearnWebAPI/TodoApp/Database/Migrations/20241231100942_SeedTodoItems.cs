using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class SeedTodoItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "DateCreated", "IsCompleted", "Title" },
                values: new object[] { new Guid("7942ea38-6b67-4e69-86c5-e1d6919baf59"), new DateTime(2024, 12, 31, 15, 39, 41, 948, DateTimeKind.Local).AddTicks(280), false, "Configure EF seed data" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "DateCreated", "IsCompleted", "Title" },
                values: new object[] { new Guid("c6436da2-d38f-4898-b085-59632f8acc94"), new DateTime(2024, 12, 31, 15, 39, 41, 948, DateTimeKind.Local).AddTicks(291), false, "Make your first GET request" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "DateCreated", "IsCompleted", "Title" },
                values: new object[] { new Guid("db3c17a7-a315-49c1-bba1-66f8a4a50425"), new DateTime(2024, 12, 31, 15, 39, 41, 948, DateTimeKind.Local).AddTicks(292), false, "Test your first GET request" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
