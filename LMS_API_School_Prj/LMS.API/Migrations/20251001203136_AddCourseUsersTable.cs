using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("0469a831-197b-4795-b05d-0016cafcef16"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("3ccdff16-e159-41ed-9970-75720c1dd5b8"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("3d68ecfb-9934-4b90-981d-c739aa990aed"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("f0e204a6-e2b2-4dbf-b3e2-ba363eb3ca46"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3596));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("1fed9cea-6a0f-4680-813f-cf3d6020cc73"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3913), "Kimenatics", new DateTime(2025, 11, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3913) },
                    { new Guid("239ae192-0c55-4b47-9872-19f20014591b"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3910), "Vektors", new DateTime(2025, 10, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3910) },
                    { new Guid("36e4632a-6660-4664-9c83-b1d388f88d30"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3908), "Polynomials", new DateTime(2025, 11, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3907) },
                    { new Guid("65f4170b-b3ba-4a07-8533-571c7b80bb74"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3897), "Functions", new DateTime(2025, 10, 1, 20, 31, 35, 804, DateTimeKind.Utc).AddTicks(3894) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("1fed9cea-6a0f-4680-813f-cf3d6020cc73"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("239ae192-0c55-4b47-9872-19f20014591b"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("36e4632a-6660-4664-9c83-b1d388f88d30"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("65f4170b-b3ba-4a07-8533-571c7b80bb74"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2025, 10, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2025, 10, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2817));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("0469a831-197b-4795-b05d-0016cafcef16"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2025, 12, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2994), "Polynomials", new DateTime(2025, 11, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2993) },
                    { new Guid("3ccdff16-e159-41ed-9970-75720c1dd5b8"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2025, 11, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2982), "Functions", new DateTime(2025, 10, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2979) },
                    { new Guid("3d68ecfb-9934-4b90-981d-c739aa990aed"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2025, 11, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2996), "Vektors", new DateTime(2025, 10, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2996) },
                    { new Guid("f0e204a6-e2b2-4dbf-b3e2-ba363eb3ca46"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2025, 12, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2998), "Kimenatics", new DateTime(2025, 11, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2998) }
                });
        }
    }
}
