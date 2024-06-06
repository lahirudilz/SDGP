using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace susFaceGen.Migrations
{
    /// <inheritdoc />
    public partial class add_account_enable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5209a25e-f512-4033-9af1-103ed3d336cb", "8ad2fcce-9df3-464a-86fb-175df6b9ec94", "admin", "ADMIN" },
                    { "561b4c9b-0b71-4630-ae83-c6691178e551", "5e30a715-a767-4b7b-8187-aa7d32991117", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "IsEnabled", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5cbda640-0d75-4f88-824a-1353c7506f97", 0, "c2f6e7c7-ee82-414c-8025-81bb032c82e0", "dev@susfaceGen.lk", false, "dev", true, "0000", "susFaceGenDev", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAEF6NO9pUILMAIpQtlVemz6DlQCOyGYeW+KM1ESmJZwbWArCmEW+aOr54nn9IJNYfsg==", null, false, "f363d034-8098-405a-9d77-8873c8d5252b", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5209a25e-f512-4033-9af1-103ed3d336cb", "5cbda640-0d75-4f88-824a-1353c7506f97" },
                    { "561b4c9b-0b71-4630-ae83-c6691178e551", "5cbda640-0d75-4f88-824a-1353c7506f97" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5209a25e-f512-4033-9af1-103ed3d336cb", "5cbda640-0d75-4f88-824a-1353c7506f97" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "561b4c9b-0b71-4630-ae83-c6691178e551", "5cbda640-0d75-4f88-824a-1353c7506f97" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5209a25e-f512-4033-9af1-103ed3d336cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561b4c9b-0b71-4630-ae83-c6691178e551");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cbda640-0d75-4f88-824a-1353c7506f97");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "AspNetUsers");

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
    }
}
