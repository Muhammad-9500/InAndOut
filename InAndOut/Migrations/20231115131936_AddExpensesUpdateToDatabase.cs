using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InAndOut.Migrations
{
    /// <inheritdoc />
    public partial class AddExpensesUpdateToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Expenses",
                newName: "ExpenseName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseName",
                table: "Expenses",
                newName: "Name");
        }
    }
}
