using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDev.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullableColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "SalaryOrBonus",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Employee",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Department",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "149055ca-4cef-4a69-a748-9ee10324e6dc", "AQAAAAEAACcQAAAAEEJjRXK6h/SKoKlSqS/9C+cL5t/s2Ob5KQuDU3ZOoItxB7Op9YqmGDjhmPGfaFZLjQ==", "8a2561da-601c-4f37-a5f3-7c529d474ce9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "SalaryOrBonus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Employee",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Department",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "987f03d6-5da0-4618-94a5-02cdd8068638", "AQAAAAEAACcQAAAAEHqhYmzretrTs7lt85dkRJP6ufCO98jDrI75ZQQIq1ML1al1kIRKdx+3aMChPShjkQ==", "9cd9b6b3-089e-4394-afdb-bc49ff058fe7" });
        }
    }
}
