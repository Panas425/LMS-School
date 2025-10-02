using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.API.Migrations
{
    /// <inheritdoc />
    public partial class DropCourseUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("3f22c609-a04e-4281-b05e-009db3769a2e"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("7f132efd-4e0f-4a7a-9329-94ae9737e8ef"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("7fd5351a-1287-4463-a139-2d724e3a7210"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("b466d296-fb59-4a64-96f2-c2dc1ba63101"));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleInCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUsers", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUsers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                columns: new[] { "End", "Start" },
                values: new object[] { null, new DateTime(2025, 10, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                columns: new[] { "End", "Start" },
                values: new object[] { null, new DateTime(2025, 10, 1, 20, 30, 51, 896, DateTimeKind.Utc).AddTicks(2817) });

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_CourseId",
                table: "CourseUsers",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseUsers");

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

            migrationBuilder.DropColumn(
                name: "End",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6f01e571-41f0-4789-8059-422ae07d736e"),
                column: "Start",
                value: new DateTime(2024, 10, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"),
                column: "Start",
                value: new DateTime(2024, 10, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6489));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "End", "Name", "Start" },
                values: new object[,]
                {
                    { new Guid("3f22c609-a04e-4281-b05e-009db3769a2e"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Polynomials", new DateTime(2024, 12, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6684), "Polynomials", new DateTime(2024, 11, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6683) },
                    { new Guid("7f132efd-4e0f-4a7a-9329-94ae9737e8ef"), new Guid("6f01e571-41f0-4789-8059-422ae07d736e"), "Intro to Functions", new DateTime(2024, 11, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6672), "Functions", new DateTime(2024, 10, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6670) },
                    { new Guid("7fd5351a-1287-4463-a139-2d724e3a7210"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Vektors", new DateTime(2024, 11, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6687), "Vektors", new DateTime(2024, 10, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6686) },
                    { new Guid("b466d296-fb59-4a64-96f2-c2dc1ba63101"), new Guid("a767cdee-e833-427a-9349-3ee71cca8a39"), "Intro to Kinematics", new DateTime(2024, 12, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6689), "Kimenatics", new DateTime(2024, 11, 5, 6, 14, 51, 938, DateTimeKind.Utc).AddTicks(6688) }
                });
        }
    }
}
