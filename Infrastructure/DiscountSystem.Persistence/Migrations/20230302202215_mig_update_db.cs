using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountSystem.Persistence.Migrations
{
    public partial class mig_update_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Discounts",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Discounts",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(string),
                oldType: "varchar(500)");
        }
    }
}
