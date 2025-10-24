using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class Editcourseuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("34a2e4a7-c88a-4cba-8fbc-06235d0aae22"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("76c15667-b4d2-4031-8e11-c221a95331c8"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("7c187b8a-6a59-48c3-a6d7-f38c1249ed7d"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9158867a-14eb-474f-9b2a-8fa4ce4dcf05"));

            migrationBuilder.AddColumn<bool>(
                name: "isPresent",
                table: "CourseUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "isPresent",
                table: "CourseUsers");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("34a2e4a7-c88a-4cba-8fbc-06235d0aae22"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4259), "Kimenatics", new DateTime(2025, 11, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4258) },
                    { new Guid("76c15667-b4d2-4031-8e11-c221a95331c8"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4232), "Functions", new DateTime(2025, 10, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4230) },
                    { new Guid("7c187b8a-6a59-48c3-a6d7-f38c1249ed7d"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4256), "Vektors", new DateTime(2025, 10, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4256) },
                    { new Guid("9158867a-14eb-474f-9b2a-8fa4ce4dcf05"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4241), "Polynomials", new DateTime(2025, 11, 24, 1, 9, 30, 830, DateTimeKind.Utc).AddTicks(4240) }
                });
        }
    }
}
