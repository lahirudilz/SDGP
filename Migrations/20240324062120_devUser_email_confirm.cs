using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace susFaceGen.Migrations
{
    /// <inheritdoc />
    public partial class devUser_email_confirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d733944e-7734-4d30-974f-5fe9a9f40ed9", "64040dab-3dca-4ec6-87ba-088b465ea72d", "admin", "ADMIN" },
                    { "dc275ceb-ac3f-4b8c-a351-7b879a3c304d", "f2b0cc1d-7fba-4e7a-b578-064307bb60f5", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "IsEnabled", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f2375f1-cc2e-4393-9e9d-63c9b837fec9", 0, "18764e8a-2e9e-497b-a114-4406166c4301", "dev@susfaceGen.lk", true, "dev", true, "0000", "susFaceGenDev", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAELnZzb+iplpiOoLIvWU+3nD5lvWQP9ezEZGlfB6RgBjxa34SQCxCbsfZzOeasqlYYQ==", null, false, "f12e9315-fcd7-4321-9db1-db21da9a11ce", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d733944e-7734-4d30-974f-5fe9a9f40ed9", "3f2375f1-cc2e-4393-9e9d-63c9b837fec9" },
                    { "dc275ceb-ac3f-4b8c-a351-7b879a3c304d", "3f2375f1-cc2e-4393-9e9d-63c9b837fec9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d733944e-7734-4d30-974f-5fe9a9f40ed9", "3f2375f1-cc2e-4393-9e9d-63c9b837fec9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc275ceb-ac3f-4b8c-a351-7b879a3c304d", "3f2375f1-cc2e-4393-9e9d-63c9b837fec9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d733944e-7734-4d30-974f-5fe9a9f40ed9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc275ceb-ac3f-4b8c-a351-7b879a3c304d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2375f1-cc2e-4393-9e9d-63c9b837fec9");

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
    }
}
