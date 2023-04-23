using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDev.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedDepartmentInEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7c123b9-5fe5-41ba-9da9-a95b9172bff5", "AQAAAAEAACcQAAAAEJRs85wy45TDVNVIvi58yxsCM2HF/BXkCNStIQMwrFIGa1UWcsloehJ4gh9OBhGhSg==", "cb1276a5-0723-47f6-900c-3197ce283f0f" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42ce0753-544a-4a0e-b8ce-2f136c7b0897", "AQAAAAEAACcQAAAAEGkxHe32YkS8SFpcBtoFWoW9dRB+XdM+x8Jxs/cAiu8HPxid14uPMQTIuRjW/hY8zg==", "8751af76-9083-43b9-8548-82374377ea3f" });
        }
    }
}
