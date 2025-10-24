using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseUsersRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
