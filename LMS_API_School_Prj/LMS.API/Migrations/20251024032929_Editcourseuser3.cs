using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class Editcourseuser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("073bd980-0561-4587-aefa-0f3ea8881506"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("5310e9e3-87e1-4c9e-a453-322285147400"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("7ec9a0b5-7221-41b1-8121-3aeeb9080c8e"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("eac6c966-0d3a-45ef-8523-83b5fbb0daa7"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("16a8ed31-08fb-4772-9ddd-b1b584e59760"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3340), "Vektors", new DateTime(2025, 10, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3340) },
                    { new Guid("52654fd6-8dd9-48e5-9b5d-35c0d2da5418"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3338), "Polynomials", new DateTime(2025, 11, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3337) },
                    { new Guid("780dacb0-a74e-400c-b3c5-e3f88a36cc99"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3343), "Kimenatics", new DateTime(2025, 11, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3342) },
                    { new Guid("94bbcb5d-75cd-4b16-9e08-4f8e04acd86b"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3329), "Functions", new DateTime(2025, 10, 24, 3, 29, 29, 221, DateTimeKind.Utc).AddTicks(3324) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("16a8ed31-08fb-4772-9ddd-b1b584e59760"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("52654fd6-8dd9-48e5-9b5d-35c0d2da5418"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("780dacb0-a74e-400c-b3c5-e3f88a36cc99"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("94bbcb5d-75cd-4b16-9e08-4f8e04acd86b"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("073bd980-0561-4587-aefa-0f3ea8881506"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3949), "Kimenatics", new DateTime(2025, 11, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3948) },
                    { new Guid("5310e9e3-87e1-4c9e-a453-322285147400"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3935), "Functions", new DateTime(2025, 10, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3932) },
                    { new Guid("7ec9a0b5-7221-41b1-8121-3aeeb9080c8e"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3943), "Polynomials", new DateTime(2025, 11, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3942) },
                    { new Guid("eac6c966-0d3a-45ef-8523-83b5fbb0daa7"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3946), "Vektors", new DateTime(2025, 10, 24, 1, 53, 55, 847, DateTimeKind.Utc).AddTicks(3945) }
                });
        }
    }
}
