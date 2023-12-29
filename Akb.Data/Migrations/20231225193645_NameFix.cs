using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akb.Data.Migrations
{
    /// <inheritdoc />
    public partial class NameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Counrty",
                schema: "dbo",
                table: "Address",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                schema: "dbo",
                table: "Address",
                newName: "Counrty");
        }
    }
}
