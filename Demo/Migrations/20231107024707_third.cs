using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cusrtomers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cusrtomers",
                table: "Cusrtomers");

            migrationBuilder.RenameTable(
                name: "Cusrtomers",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Cusrtomers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cusrtomers",
                table: "Cusrtomers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cusrtomers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Cusrtomers",
                principalColumn: "Id");
        }
    }
}
