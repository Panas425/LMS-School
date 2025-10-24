using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class Editstudentname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6111));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("a985120e-7be7-4312-a1f4-f2a918af7085"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6279), "Polynomials", new DateTime(2025, 11, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6278) },
                    { new Guid("b3b4601a-58e4-4305-b193-8b41b3bec3b1"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6270), "Functions", new DateTime(2025, 10, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6267) },
                    { new Guid("c10260aa-b01a-4c7c-90e5-4543e60d9995"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6290), "Kimenatics", new DateTime(2025, 11, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6289) },
                    { new Guid("c8f98b35-4b77-4662-bee4-21eaa78e572f"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6287), "Vektors", new DateTime(2025, 10, 24, 16, 49, 34, 740, DateTimeKind.Utc).AddTicks(6287) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a985120e-7be7-4312-a1f4-f2a918af7085"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("b3b4601a-58e4-4305-b193-8b41b3bec3b1"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("c10260aa-b01a-4c7c-90e5-4543e60d9995"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("c8f98b35-4b77-4662-bee4-21eaa78e572f"));

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Submissions");

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
    }
}
