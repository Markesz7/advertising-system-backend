using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class SeedNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9a0e5c0-9360-4e55-9fa9-a67b70e45ad0", "AQAAAAEAACcQAAAAEBoCydQHbf/ylosvtGRGJ6cJgf0DLyfUg7+/s7i/jpdEUiEGhUrRu+ZlajAOYVX8lg==" });

            migrationBuilder.InsertData(
                table: "Revenues",
                columns: new[] { "Id", "Amount", "Date", "TransportCompanyId" },
                values: new object[] { 1, 5000, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Revenues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d79af2e-de35-4072-b0bf-691b57b8e0c6", "AQAAAAEAACcQAAAAEMDj86iSIF7b20IMIWKVyNK6WTXuLSsSpNXvQDSRp/IdQU+WuuKKzOhQYUVLrUKJSg==" });
        }
    }
}
