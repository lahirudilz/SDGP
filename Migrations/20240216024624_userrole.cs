using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace susFaceGen.Migrations
{
    /// <inheritdoc />
    public partial class userrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd7c1299-9335-41ea-8d2f-b96146121a91");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f899271-d57f-4606-b2d7-614af7e7791e", "ddc58fa3-438a-449b-84f2-214625bbb91b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f899271-d57f-4606-b2d7-614af7e7791e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddc58fa3-438a-449b-84f2-214625bbb91b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f899271-d57f-4606-b2d7-614af7e7791e", "c12de5c8-2258-495b-9017-f21ad49c8b15", "admin", "ADMIN" },
                    { "bd7c1299-9335-41ea-8d2f-b96146121a91", "a9ac0dc4-1aa7-4c79-a0d6-f7b4a113406c", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "JobId", "JobPosition", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddc58fa3-438a-449b-84f2-214625bbb91b", 0, "49aebaa9-ff8b-4eaa-a931-838d60fbd7ae", "dev@susfaceGen.lk", false, "dev", "0000", "susFaceGenDev", "dev", false, null, "DEV@SUSFACEGEN.LK", "DEV@SUSFACEGEN.LK", "AQAAAAIAAYagAAAAEEWwlPnCEqEbcMYRY2wF2aFfn8NKkSM6jJlwLCs8IE8L7PRaCag95qvETuVDlQcG5w==", null, false, "b6456a98-3e05-443e-a9ad-3df9dcf11e4e", false, "dev@susfaceGen.lk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1f899271-d57f-4606-b2d7-614af7e7791e", "ddc58fa3-438a-449b-84f2-214625bbb91b" });
        }
    }
}
