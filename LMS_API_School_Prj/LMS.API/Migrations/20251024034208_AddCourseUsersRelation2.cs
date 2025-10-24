using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseUsersRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("153f4d6d-60af-4ff7-9b81-eee4c08cf63d"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("8b8e06c0-d295-4f8f-9e7b-b9d1d959d34e"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("c332c190-52b2-45de-b277-4fcaadd887cb"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ced93b88-6d49-419e-ae96-e9b441a28323"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2025, 10, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("153f4d6d-60af-4ff7-9b81-eee4c08cf63d"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(4004), "Vektors", new DateTime(2025, 10, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(4004) },
                    { new Guid("8b8e06c0-d295-4f8f-9e7b-b9d1d959d34e"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(4002), "Polynomials", new DateTime(2025, 11, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(4001) },
                    { new Guid("c332c190-52b2-45de-b277-4fcaadd887cb"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(4007), "Kimenatics", new DateTime(2025, 11, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(4006) },
                    { new Guid("ced93b88-6d49-419e-ae96-e9b441a28323"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(3993), "Functions", new DateTime(2025, 10, 24, 3, 36, 32, 380, DateTimeKind.Utc).AddTicks(3991) }
                });
        }
    }
}
