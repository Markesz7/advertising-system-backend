using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "92cfff66-5057-40c8-ab2b-f55141ebd26e", "transportcompany", "TRANSPORTCOMPANY" },
                    { 2, "a430251e-bf92-40ab-ae44-3c4fd2ee2215", "adorganizer", "ADORGANIZER" },
                    { 3, "ec568bd3-f902-4c53-8664-e7365a99fdc8", "advertiser", "ADVERTISER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51d28da5-8ffc-4561-83f0-10ff476a3a55", "AQAAAAEAACcQAAAAEFP6NQk67a2yc4FQc/UGeEisxEF8a18rtxnGmdM6gUIAfOdR/Hsl6+U9buJVF7VARw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7740174e-bce6-4c88-b23e-c6e72968978e", "AQAAAAEAACcQAAAAEJZ8Q/9Ma53GxbCImGPZRhJN2KfYSlHpjHwquh75hDQ102WZs5TYaCb4XLsauFuQXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c126a0a-891f-45b0-8eb4-a3f2e03ac63a", "AQAAAAEAACcQAAAAELZtBbCcXNYwivnSuifGgDRCEjR3KbVOYZr4BjkIrnObWWpFM16hD+BQAiDu9/+cUg==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bfe4b498-2974-451a-ace3-92a4efe9f0c1", "AQAAAAEAACcQAAAAEF1dskg7PG8Y9rj4pEICJa+MYkmhrG690/I75aKqaquaNUjMoVo+IF3aLoDJyZF8MQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b317d509-519a-4ff9-896f-8262c19cd72a", "AQAAAAEAACcQAAAAEFB/grqA/Y2QwuBcMof38gZO1yAm8NeUZCXEwD8r2yZIbBCjGekc7bFPieQY4zXaDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30237430-d210-48a1-8885-9a72c2be56af", "AQAAAAEAACcQAAAAELvEYcm6uOeq3/oSnGDuiyz7bEqORkcmskz9jkT05xSTridU8srQUKDmjJ36zJsgXQ==" });
        }
    }
}
