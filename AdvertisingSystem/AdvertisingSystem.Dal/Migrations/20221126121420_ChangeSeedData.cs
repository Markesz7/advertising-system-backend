using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class ChangeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d105a3f8-8326-4d0b-8702-1dd05b1c292f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "06c1866d-8342-4058-9ca8-becf48af5801");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6bd546e5-1692-4b65-a9d3-d5a42eafd0df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "7b706058-f07d-46b7-b1a2-d83f01dba513", "TESTADORG", "AQAAAAEAACcQAAAAED00lMiLz0oNYn+i73c2E4mZFJoWVmztgAZY/T8fMFzm9LZXqMgwXjP1kSHWZuQ/+g==", "testadorg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "6bc0efe3-7962-449e-bea3-e8d0680fdec5", "TESTADV", "AQAAAAEAACcQAAAAEE31gxXLX7K2sdroaRxdUN5g2jR1UQdM/m3M28PnA0N9FHKEY00dVcc6QHLiwky3TA==", "testadv" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "8303402d-e1ed-4936-b424-d22add72841f", "TESTTC", "AQAAAAEAACcQAAAAEANl+Xw3L5h+TnawJ5nsRXDIDwrbMjMFBJBbsEhWuwD6LQEDAYbiW1YPACIZbLP5Cg==", "testtc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "7d19096f-406d-4b9d-a3ed-0e69b5a3cd19", null, "AQAAAAEAACcQAAAAEKTaCnVcd/zOMQLjojs0m525aKsiFAv9SzjTnHWfRrQ5Fn6hkuElDPdl7nKPt6LCDw==", "t3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "0a2cbf1d-729c-494d-9e45-ad864230ff35", null, "AQAAAAEAACcQAAAAEOV+Kxlm5jEtjWTFei/SzCGovsOC1KqQZTR09k6T28OJvcdk3HuL37s0MOMC9PgCXw==", "t2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "6a505445-b9ff-4525-be68-91003aee693f", null, "AQAAAAEAACcQAAAAECw2tFoQKZN6ib45jwz7WwGOz8qHWq+vUSQlldU4rV9RP69lwtTNtWL7E3IM+AT3/w==", "t" });
        }
    }
}
