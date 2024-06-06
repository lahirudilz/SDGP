using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace susFaceGen.Migrations
{
    /// <inheritdoc />
    public partial class devUser_remove_normalUserAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4a86dde3-1382-4c4b-b5c5-1631b63da3b3", "8b36f33c-0f49-4230-b52f-1f1d5ba47167", "user", "USER" },
                    { "734eae79-c17a-418a-9ef4-c4b80b3b249a", "b5c09043-3711-492e-9830-8886d41e03f4", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "IsEnabled", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5fca3590-00c9-4b89-b050-cbae112c6e24", 0, "b84ba6c5-f6c7-476a-a2c1-2dd326ed3e74", "dev@susfaceGen.lk", true, "dev", true, "0000", "Global Admin", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAECtzM6XnOgWrDpaovxCEMh5WDarSi+YEXEp0Hh/UQB+9o+iKrziL7sz5uU482VQDig==", null, false, "c3d7dbe8-d6c8-4036-a768-352a5a18ded0", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "734eae79-c17a-418a-9ef4-c4b80b3b249a", "5fca3590-00c9-4b89-b050-cbae112c6e24" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a86dde3-1382-4c4b-b5c5-1631b63da3b3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "734eae79-c17a-418a-9ef4-c4b80b3b249a", "5fca3590-00c9-4b89-b050-cbae112c6e24" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "734eae79-c17a-418a-9ef4-c4b80b3b249a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fca3590-00c9-4b89-b050-cbae112c6e24");

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
    }
}
