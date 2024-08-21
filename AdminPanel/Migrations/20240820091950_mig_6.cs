using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPanel.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84c03e0c-6316-4e1e-82b9-33c2974da603", "AQAAAAIAAYagAAAAEEMm/d3r0DQCoWvUW5b36Y036tCyMzFTh151n3HX3mGqXTgn4F1019kG6s6RZWIfUQ==", "e58267a0-8bb0-4290-a3f7-79f6d280c42f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1afe8dd-2539-411a-a8e0-7850927ef79d", "AQAAAAIAAYagAAAAEMTWR4IJAZZKlhvB2ow4/ziNp0E+vREjDeZFauWMPyyPCue3WmPUB3y2h0G7J+G0BQ==", "3210e755-6c78-4220-bb53-dbf257d950bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06033aff-1733-4a60-9871-824e5b7f29a7", "AQAAAAIAAYagAAAAEO0UnySBJ0Prqr0eZ9eXj0MI3N1lbRhSRlUWKOiuimiyS5BPxj3aDOdfstnabHP1QQ==", "2c03fdb9-beaf-4386-972c-fca12cd29af1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ab5b23-72bc-4f05-969a-9fccfcc7abbe", "AQAAAAIAAYagAAAAEMNjBDbFzr76PSD/sEMmsJ4OcdLgAEDoBfpkIGAdjHJyaMkRiZbC0XPUu3CSkJSo4w==", "77d6d054-5374-4dde-aafb-4661280f728d" });
        }
    }
}
