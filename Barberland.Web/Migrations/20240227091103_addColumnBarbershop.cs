using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barberland.Web.Migrations
{
    /// <inheritdoc />
    public partial class addColumnBarbershop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "barbershop",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "barbershop",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "barbershop",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "operational_hour",
                table: "barbershop",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "province",
                table: "barbershop",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "barbershop");

            migrationBuilder.DropColumn(
                name: "city",
                table: "barbershop");

            migrationBuilder.DropColumn(
                name: "district",
                table: "barbershop");

            migrationBuilder.DropColumn(
                name: "operational_hour",
                table: "barbershop");

            migrationBuilder.DropColumn(
                name: "province",
                table: "barbershop");
        }
    }
}
