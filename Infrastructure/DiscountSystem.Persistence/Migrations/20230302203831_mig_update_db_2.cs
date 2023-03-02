using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountSystem.Persistence.Migrations
{
    public partial class mig_update_db_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Discounts",
                type: "decimal(20,5)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Discounts");
        }
    }
}
