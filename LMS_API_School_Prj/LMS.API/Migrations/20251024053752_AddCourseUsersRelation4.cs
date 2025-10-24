using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseUsersRelation4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2025, 10, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("2b89a9ed-462d-452f-b592-f368267ac385"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2904), "Kimenatics", new DateTime(2025, 11, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2903) },
                    { new Guid("934509ed-0b94-43d7-8c06-5f26ec1ef74a"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2898), "Polynomials", new DateTime(2025, 11, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2897) },
                    { new Guid("c1cfc06d-6c94-4ed7-8dc2-d621cdbd131a"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2901), "Vektors", new DateTime(2025, 10, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2901) },
                    { new Guid("f018fc20-eec1-4c89-aa21-bc7b6736bf0f"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2890), "Functions", new DateTime(2025, 10, 24, 5, 37, 52, 179, DateTimeKind.Utc).AddTicks(2887) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("2b89a9ed-462d-452f-b592-f368267ac385"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("934509ed-0b94-43d7-8c06-5f26ec1ef74a"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("c1cfc06d-6c94-4ed7-8dc2-d621cdbd131a"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("f018fc20-eec1-4c89-aa21-bc7b6736bf0f"));

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
    }
}
