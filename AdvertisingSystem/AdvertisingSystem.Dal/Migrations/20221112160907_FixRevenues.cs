using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class FixRevenues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenue_AspNetUsers_TransportCompanyId",
                table: "Revenue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenue",
                table: "Revenue");

            migrationBuilder.RenameTable(
                name: "Revenue",
                newName: "Revenues");

            migrationBuilder.RenameIndex(
                name: "IX_Revenue_TransportCompanyId",
                table: "Revenues",
                newName: "IX_Revenues_TransportCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d79af2e-de35-4072-b0bf-691b57b8e0c6", "AQAAAAEAACcQAAAAEMDj86iSIF7b20IMIWKVyNK6WTXuLSsSpNXvQDSRp/IdQU+WuuKKzOhQYUVLrUKJSg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_AspNetUsers_TransportCompanyId",
                table: "Revenues",
                column: "TransportCompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_AspNetUsers_TransportCompanyId",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues");

            migrationBuilder.RenameTable(
                name: "Revenues",
                newName: "Revenue");

            migrationBuilder.RenameIndex(
                name: "IX_Revenues_TransportCompanyId",
                table: "Revenue",
                newName: "IX_Revenue_TransportCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenue",
                table: "Revenue",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d79e1e4-f9f4-4dfb-b9e8-fc31634681ad", "AQAAAAEAACcQAAAAEMcjh/0hjQF68XNIOrf1a9kdl/PzLuSRucm/rv9SvB555ojWLqE5qgrEkLIchNIvHA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Revenue_AspNetUsers_TransportCompanyId",
                table: "Revenue",
                column: "TransportCompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
