using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class SeedMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d43728cf-246c-484e-8bf9-9a2d5005306c", "AQAAAAEAACcQAAAAEMfMyDYusWsUg88yCCNAkEqu+HFsHYLp9agYXwa3SV3aDp7Chp/VJSbgYVTT6nVLlg==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "1dde86ad-e3ba-4525-8e1c-0293f2e34ee2", "AdOrganiser", "testAdOrg@test.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEB2vOw59LhKKrIUciZPvB4jASLV6SSQ8OGCGJHe9xWskHIsFDDrixEHLTt9otw3NEw==", null, false, null, false, "t3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Enabled", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "722333de-792a-4ba5-9891-b779bf6739d7", "Advertiser", "testAdvertiser@test.com", true, true, false, null, 100, null, null, "AQAAAAEAACcQAAAAECKPC9zoYL4JjmXxsY8hydzJmMtzNA1TSepCCiCiiw71HxUUPXgIbprTFkMVoe55bw==", null, true, null, false, "t2" });

            migrationBuilder.InsertData(
                table: "Transportlines",
                columns: new[] { "Id", "EndTime", "Group", "Name", "StartTime", "TransportCompanyId" },
                values: new object[] { 1, new TimeSpan(0, 16, 27, 0, 0), "Bus", "5A", new TimeSpan(0, 15, 42, 0, 0), 1 });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "AdURL", "AdvertiserId", "EndTime", "Occurence", "PaymentMethod", "PlaceGroups", "StartTime" },
                values: new object[] { 1, "test.com", 2, null, 0, "Monthly", "Tram", null });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "AdURL", "AdvertiserId", "EndTime", "Occurence", "PaymentMethod", "PlaceGroups", "StartTime" },
                values: new object[] { 2, "test2.com", 2, null, 0, "Wallet", "Bus", null });

            migrationBuilder.InsertData(
                table: "AdTransportline",
                columns: new[] { "AdsId", "TransportlinesId" },
                values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdTransportline",
                keyColumns: new[] { "AdsId", "TransportlinesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transportlines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9a0e5c0-9360-4e55-9fa9-a67b70e45ad0", "AQAAAAEAACcQAAAAEBoCydQHbf/ylosvtGRGJ6cJgf0DLyfUg7+/s7i/jpdEUiEGhUrRu+ZlajAOYVX8lg==" });
        }
    }
}
