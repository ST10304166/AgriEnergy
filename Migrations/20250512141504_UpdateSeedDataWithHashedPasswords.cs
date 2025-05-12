using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataWithHashedPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$bnQYLcW.mphB175V2EzqO.DTXuSaDE829dqsL4YUTf.KDTbHqwP1y");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RegistrationDate" },
                values: new object[] { "$2a$11$YPPoV9pzzGMyJsDic1r7DOHTVuhnq3PbNMZouYbuQSXdtTCMtDIlm", new DateTime(2025, 5, 12, 16, 15, 4, 184, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2025, 5, 2, 16, 15, 4, 303, DateTimeKind.Local).AddTicks(1322));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin123");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RegistrationDate" },
                values: new object[] { "password123", new DateTime(2025, 5, 12, 4, 8, 0, 546, DateTimeKind.Local).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2025, 5, 2, 4, 8, 0, 547, DateTimeKind.Local).AddTicks(64));
        }
    }
}
