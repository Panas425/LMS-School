using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseUsersRelation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("1c373678-d4f0-4e71-873d-343bf050bad7"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("495651c6-c8b0-4405-bf32-834bc99ed13a"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("67f57502-3abe-4d2e-9022-c64577f1f3bd"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("fc0ef1b4-26b1-451a-b364-ac0a614b7b10"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("01350641-87f9-4d44-ae33-bad746103394"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1486), "Functions", new DateTime(2025, 10, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1484) },
                    { new Guid("15c10ead-c8f2-468a-aa9c-adfd93d5b535"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1501), "Vektors", new DateTime(2025, 10, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1496) },
                    { new Guid("75a2a421-d52d-4240-ad0d-4826117716de"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1495), "Polynomials", new DateTime(2025, 11, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1494) },
                    { new Guid("898a2362-cc1e-4353-92f0-42123bdc6596"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1503), "Kimenatics", new DateTime(2025, 11, 24, 5, 12, 57, 204, DateTimeKind.Utc).AddTicks(1503) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("01350641-87f9-4d44-ae33-bad746103394"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("15c10ead-c8f2-468a-aa9c-adfd93d5b535"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("75a2a421-d52d-4240-ad0d-4826117716de"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("898a2362-cc1e-4353-92f0-42123bdc6596"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("1c373678-d4f0-4e71-873d-343bf050bad7"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7112), "Polynomials", new DateTime(2025, 11, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7111) },
                    { new Guid("495651c6-c8b0-4405-bf32-834bc99ed13a"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7117), "Kimenatics", new DateTime(2025, 11, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7116) },
                    { new Guid("67f57502-3abe-4d2e-9022-c64577f1f3bd"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7114), "Vektors", new DateTime(2025, 10, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7114) },
                    { new Guid("fc0ef1b4-26b1-451a-b364-ac0a614b7b10"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7099), "Functions", new DateTime(2025, 10, 24, 3, 42, 8, 221, DateTimeKind.Utc).AddTicks(7096) }
                });
        }
    }
}
