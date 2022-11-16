using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    public partial class AddAdBanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    SerializedVehicleNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdBans_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdBanTransportline",
                columns: table => new
                {
                    AdBansId = table.Column<int>(type: "int", nullable: false),
                    TransportlinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdBanTransportline", x => new { x.AdBansId, x.TransportlinesId });
                    table.ForeignKey(
                        name: "FK_AdBanTransportline_AdBans_AdBansId",
                        column: x => x.AdBansId,
                        principalTable: "AdBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdBanTransportline_Transportlines_TransportlinesId",
                        column: x => x.TransportlinesId,
                        principalTable: "Transportlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AdBans_AdId",
                table: "AdBans",
                column: "AdId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdBanTransportline_TransportlinesId",
                table: "AdBanTransportline",
                column: "TransportlinesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdBanTransportline");

            migrationBuilder.DropTable(
                name: "AdBans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1dde86ad-e3ba-4525-8e1c-0293f2e34ee2", "AQAAAAEAACcQAAAAEB2vOw59LhKKrIUciZPvB4jASLV6SSQ8OGCGJHe9xWskHIsFDDrixEHLTt9otw3NEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "722333de-792a-4ba5-9891-b779bf6739d7", "AQAAAAEAACcQAAAAECKPC9zoYL4JjmXxsY8hydzJmMtzNA1TSepCCiCiiw71HxUUPXgIbprTFkMVoe55bw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d43728cf-246c-484e-8bf9-9a2d5005306c", "AQAAAAEAACcQAAAAEMfMyDYusWsUg88yCCNAkEqu+HFsHYLp9agYXwa3SV3aDp7Chp/VJSbgYVTT6nVLlg==" });
        }
    }
}
