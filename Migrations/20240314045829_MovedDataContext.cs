using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace susFaceGen.Migrations
{
    /// <inheritdoc />
    public partial class MovedDataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "743ce5ee-3606-4957-97f4-7a3ec8056718", "98ec36f5-5e74-43eb-bf7c-8c5d797c8663" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "939cdd3f-af49-4164-9b3f-c1df9424dcb8", "98ec36f5-5e74-43eb-bf7c-8c5d797c8663" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "743ce5ee-3606-4957-97f4-7a3ec8056718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "939cdd3f-af49-4164-9b3f-c1df9424dcb8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98ec36f5-5e74-43eb-bf7c-8c5d797c8663");

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseRefNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestigatingOfficerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatementRefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorOfHair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfHead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorTypeOfEyes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShapeOfEyes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mouth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teeth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Face = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ears = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Forhead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HairOnHead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacialHair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complexion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeBrows = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EyewitnessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyewitnessNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statement_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65ea7452-5ab2-4906-b61c-e0a7784c5140", "09269125-36d3-412d-b38b-62e54068b53a", "user", "USER" },
                    { "a579bd0b-1616-4bdf-8928-334f713cd95f", "0cf70722-0e51-4b44-949b-edf2ffbd882b", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0f288095-00aa-4da2-bcfe-8ac84168e652", 0, "351a277c-8831-4f62-9f66-35c421f57a67", "dev@susfaceGen.lk", false, "dev", "0000", "susFaceGenDev", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAEMl9azHZhUS3zm8R5fyx4ggbIed4glrovQpArzOXl5/tuCHKNyK/b/EXeDoS6aULnQ==", null, false, "43efa358-c488-444c-b875-69abc663e302", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "65ea7452-5ab2-4906-b61c-e0a7784c5140", "0f288095-00aa-4da2-bcfe-8ac84168e652" },
                    { "a579bd0b-1616-4bdf-8928-334f713cd95f", "0f288095-00aa-4da2-bcfe-8ac84168e652" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_UserId",
                table: "Case",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_CaseId",
                table: "Statement",
                column: "CaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65ea7452-5ab2-4906-b61c-e0a7784c5140", "0f288095-00aa-4da2-bcfe-8ac84168e652" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a579bd0b-1616-4bdf-8928-334f713cd95f", "0f288095-00aa-4da2-bcfe-8ac84168e652" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65ea7452-5ab2-4906-b61c-e0a7784c5140");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a579bd0b-1616-4bdf-8928-334f713cd95f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f288095-00aa-4da2-bcfe-8ac84168e652");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "743ce5ee-3606-4957-97f4-7a3ec8056718", "76333486-622f-4cf5-8dde-b33c8413c84c", "user", "USER" },
                    { "939cdd3f-af49-4164-9b3f-c1df9424dcb8", "51e80f90-3d98-4d64-a778-4f8884e74e6e", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98ec36f5-5e74-43eb-bf7c-8c5d797c8663", 0, "241ae5ed-abd4-4928-ab79-ab13c285c943", "dev@susfaceGen.lk", false, "dev", "0000", "susFaceGenDev", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAEKL8ItYuXgWnWahgj6kffWAlKILcf0Y7L56p6m9tvHQn+Lipof4ouR3TsZ1TEKvmzQ==", null, false, "2deaab6e-bfa3-456d-a4ce-a979f706bd3f", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "743ce5ee-3606-4957-97f4-7a3ec8056718", "98ec36f5-5e74-43eb-bf7c-8c5d797c8663" },
                    { "939cdd3f-af49-4164-9b3f-c1df9424dcb8", "98ec36f5-5e74-43eb-bf7c-8c5d797c8663" }
                });
        }
    }
}
