using Microsoft.EntityFrameworkCore.Migrations;

namespace BougieCandles.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "261cdfd5-ab93-4261-a51a-7e0888dfed39");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bbc10f6-0565-4a95-b857-f044a6004284", "50f582f6-7514-457b-943c-4fbc2a48e429", "Users", "USERS" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d97265a-92f0-44af-a461-f69817e04162", "569f22de-4036-497f-bea8-e748a5269a5c", "Customer", "CUSTOMERS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1d97265a-92f0-44af-a461-f69817e04162");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5bbc10f6-0565-4a95-b857-f044a6004284");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "261cdfd5-ab93-4261-a51a-7e0888dfed39", "0d4ce509-6e21-49cc-a05d-8e796c66161d", "Users", "USERS" });
        }
    }
}
