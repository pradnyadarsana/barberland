using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barberland.Web.Migrations
{
    /// <inheritdoc />
    public partial class BarberlandMigration_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "service_category_image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    is_thumbnail = table.Column<bool>(type: "boolean", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_service_category_image", x => x.id);
                    table.ForeignKey(
                        name: "fk_service_category_image_service_category_service_category_id",
                        column: x => x.service_category_id,
                        principalTable: "service_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_service_category_image_service_category_id",
                table: "service_category_image",
                column: "service_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "service_category_image");
        }
    }
}
