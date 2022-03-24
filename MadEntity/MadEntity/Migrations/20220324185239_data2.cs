using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MadEntity.Migrations
{
    public partial class data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "DepartmentId", "MiddleName", "Name", "Surname" },
                values: new object[,]
                {
                    { 3, null, null, null, "Aura", "Aura" },
                    { 4, null, null, null, "Tion", "Tion" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "DepartmentId", "MiddleName", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, null, null, null, "Aura", "Aura" },
                    { 2, null, null, null, "Tion", "Tion" }
                });
        }
    }
}
