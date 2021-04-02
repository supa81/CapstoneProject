using Microsoft.EntityFrameworkCore.Migrations;

namespace BougieCandles.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "bbf7eeb8-8cb1-4dac-bc46-f0fea482cb69");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "261cdfd5-ab93-4261-a51a-7e0888dfed39", "0d4ce509-6e21-49cc-a05d-8e796c66161d", "Users", "USERS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "261cdfd5-ab93-4261-a51a-7e0888dfed39");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbf7eeb8-8cb1-4dac-bc46-f0fea482cb69", "ade67043-426c-4556-a627-0709524b9f25", "Users", "USERS" });
        }
    }
}
