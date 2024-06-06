using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace susFaceGen.Migrations
{
    /// <inheritdoc />
    public partial class CaseModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Case",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "Case",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Case",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d2805a6-8aac-48b4-9a36-a74d0aac1152", "1657e09f-e460-4534-a500-9d39cbdceef8", "user", "USER" },
                    { "5b2f3f4b-69a9-415f-a48c-0926cf6ad61d", "ce83a322-ae51-4c74-bae8-bac79adf3bfb", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "904adf3e-52ca-4a57-8c2e-2c3b7cf9f17b", 0, "50e06ff0-7bf9-4c69-be7a-2943f4586b6f", "dev@susfaceGen.lk", false, "dev", "0000", "susFaceGenDev", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAEBPyD5u/yFBbuHsm/sUVJuekZvRXWx6v/t1P9ylwfWEt/9Ea0x7Ikin2XTJkfxSqcg==", null, false, "adc32018-8367-48bf-8434-b92c830821df", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d2805a6-8aac-48b4-9a36-a74d0aac1152", "904adf3e-52ca-4a57-8c2e-2c3b7cf9f17b" },
                    { "5b2f3f4b-69a9-415f-a48c-0926cf6ad61d", "904adf3e-52ca-4a57-8c2e-2c3b7cf9f17b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d2805a6-8aac-48b4-9a36-a74d0aac1152", "904adf3e-52ca-4a57-8c2e-2c3b7cf9f17b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b2f3f4b-69a9-415f-a48c-0926cf6ad61d", "904adf3e-52ca-4a57-8c2e-2c3b7cf9f17b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d2805a6-8aac-48b4-9a36-a74d0aac1152");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2f3f4b-69a9-415f-a48c-0926cf6ad61d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "904adf3e-52ca-4a57-8c2e-2c3b7cf9f17b");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Case");

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
        }
    }
}
