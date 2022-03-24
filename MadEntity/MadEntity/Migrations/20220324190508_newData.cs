using MadEntity.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MadEntity.Migrations
{
    public partial class newData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .InsertData(
                table: "Persons",
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Ekaterina", "Grazdankina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .DeleteData(table: "Persons",
                keyColumn: nameof(Person.Name),
                keyValue: "Ekaterina");

        }
    }
}
