using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class AddSubstituteAdURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubstituteAdURL",
                table: "AdBans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9666ab97-e94a-4e46-afbb-c9cea9b280ea", "AQAAAAEAACcQAAAAEKfpg0tsjZIXzIrHKumcv2Mahg1lecCJCU/Pt3yp9/8/qlEgSPy3CRVYttEGr87NYg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc5bd162-420d-402d-8224-80f67a4a3c48", "AQAAAAEAACcQAAAAELRf/ZmeZE3y5tC4SWdsrpzVHa84Zem+EEKzkRIHKstJTmUC69EHf9wsAc/VfSYFNg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d59c8e0-3ba5-4867-8fee-b78f88cfa553", "AQAAAAEAACcQAAAAEFgDT7XLwHl2Hp9WZgxx9WUvr7AtAZFHUd9mGMifJE8VNr2eghPMEkeV3BY2WUj1dw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubstituteAdURL",
                table: "AdBans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4ebbfc0-f3e5-4c92-9ce5-61fbeaa75783", "AQAAAAEAACcQAAAAEMQrh13E2BJT6VivUQ5DW1pdTEcK4TH4XKG+ZeQ1XobIdvHLGjtd4s9jHH2fozfHzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eac2bf9b-5d17-470e-849f-e0e37627760f", "AQAAAAEAACcQAAAAEB644cSmzFrVgfQ2xtRoTeUJAEvXqKUw48xth3xTcYXUZTrnUP1llOIlx1lmOe3gSQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9aed290-e6fe-497c-9dbd-6722c1f6451e", "AQAAAAEAACcQAAAAEB8DcudtetuG+q/rsMyghMF3GEUkcH1wFXUIfiyZOEWW/J+GZIwltkuuwpigurrBbQ==" });
        }
    }
}
