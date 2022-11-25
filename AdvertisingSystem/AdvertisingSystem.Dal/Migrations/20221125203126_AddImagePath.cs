using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class AddImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdURL", "ImagePath" },
                values: new object[] { "api/advertiser/3/image/abc123de", "images/advertisers/3/abc123de.jpg" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdURL", "ImagePath" },
                values: new object[] { "api/advertiser/3/image/cba321ed", "images/advertisers/3/cba321ed.jpg" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d05e710a-89d5-4ecd-82b1-cc85ea26a77a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f00f83a8-ee99-4783-a136-df152cb3257f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "61bce73b-06d6-454d-93ba-0dc3a27220ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d19096f-406d-4b9d-a3ed-0e69b5a3cd19", "AQAAAAEAACcQAAAAEKTaCnVcd/zOMQLjojs0m525aKsiFAv9SzjTnHWfRrQ5Fn6hkuElDPdl7nKPt6LCDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a2cbf1d-729c-494d-9e45-ad864230ff35", "AQAAAAEAACcQAAAAEOV+Kxlm5jEtjWTFei/SzCGovsOC1KqQZTR09k6T28OJvcdk3HuL37s0MOMC9PgCXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a505445-b9ff-4525-be68-91003aee693f", "AQAAAAEAACcQAAAAECw2tFoQKZN6ib45jwz7WwGOz8qHWq+vUSQlldU4rV9RP69lwtTNtWL7E3IM+AT3/w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdURL",
                value: "test.com");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdURL",
                value: "test2.com");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "92cfff66-5057-40c8-ab2b-f55141ebd26e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a430251e-bf92-40ab-ae44-3c4fd2ee2215");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ec568bd3-f902-4c53-8664-e7365a99fdc8");

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
        }
    }
}
