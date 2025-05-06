using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class EmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("7942ea38-6b67-4e69-86c5-e1d6919baf59"));

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("c6436da2-d38f-4898-b085-59632f8acc94"));

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("db3c17a7-a315-49c1-bba1-66f8a4a50425"));

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Email", "Name", "Role" },
                values: new object[] { new Guid("7416f782-d3f9-4266-8cf4-3aaacdb51046"), 25, "omdwivedy@business.com", "Omkareshwar Dwivedy", 0 });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "DateCreated", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { new Guid("1c12bbb0-174d-44fb-bd3a-2837d43a2236"), new DateTime(2025, 5, 3, 15, 45, 29, 109, DateTimeKind.Local).AddTicks(8714), false, "Test your first GET request" },
                    { new Guid("9acf1bfb-eca7-42cb-885e-dab9d777b533"), new DateTime(2025, 5, 3, 15, 45, 29, 109, DateTimeKind.Local).AddTicks(8689), false, "Make your first GET request" },
                    { new Guid("ee2e08a9-66b1-47fc-be8d-398c1192d389"), new DateTime(2025, 5, 3, 15, 45, 29, 109, DateTimeKind.Local).AddTicks(8668), false, "Configure EF seed data" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("1c12bbb0-174d-44fb-bd3a-2837d43a2236"));

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("9acf1bfb-eca7-42cb-885e-dab9d777b533"));

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("ee2e08a9-66b1-47fc-be8d-398c1192d389"));

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
    }
}
