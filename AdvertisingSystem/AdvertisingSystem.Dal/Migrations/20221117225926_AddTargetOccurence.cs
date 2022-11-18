using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class AddTargetOccurence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdTransportlines_AdBans_AdBanId",
                table: "AdTransportlines");

            migrationBuilder.AddColumn<int>(
                name: "TargetOccurence",
                table: "Ads",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e2c499e-3672-4049-9cfb-b973c3c5da52", "AQAAAAEAACcQAAAAEENi3QuJ9UohYWlwf1xlvF7QJCsUzF18GhRTTmjfDgOOUb7LMSkL5Y0FqJsvX2HUwQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71e80787-1e3e-449d-a43c-2b8595f6283a", "AQAAAAEAACcQAAAAEEXtjCnuxvol8YlrD0CtT7eHVKYQiiHpAHquRplQAOyiHiQoi8g/LhHDZgjhdJG4NA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f144090e-09a3-45c7-b16b-1984c6e23a00", "AQAAAAEAACcQAAAAEKmF9gVApKsZ41GRKsF45f95/0UdJ7dpIeAz4RsFvrY9plgMJxOjh6G/r/dCmooJ4g==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdTransportlines_AdBans_AdBanId",
                table: "AdTransportlines",
                column: "AdBanId",
                principalTable: "AdBans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdTransportlines_AdBans_AdBanId",
                table: "AdTransportlines");

            migrationBuilder.DropColumn(
                name: "TargetOccurence",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b1b878a-1192-4a47-ac4d-d089ae4c1ea3", "AQAAAAEAACcQAAAAEJ4JsyATMPCAC7+Je7AMLZJeHDw2FFhXhjs0pePMoW780H/yIyUWd2o7/DdEc8PDJA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2b0db5f-2c8f-4087-a972-0a6e2c858036", "AQAAAAEAACcQAAAAEAaeKD4nbeeIOQvrzT5RRuIBQviFrVMOVI5wPxLD/ia/CbjAsKgw0KxjcH9rbCIVUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd9b6472-1055-4c78-9bc2-a92bc6a547da", "AQAAAAEAACcQAAAAECHZcZEmfb5Xg3iFfdlshYjvi6MQBZr2FpFok7ACKJPPz7fzVwVbZxy64zJCsF9fkQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdTransportlines_AdBans_AdBanId",
                table: "AdTransportlines",
                column: "AdBanId",
                principalTable: "AdBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
