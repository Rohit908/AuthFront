using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Infrastructure.Migrations
{
    public partial class AddedIsActivePropertyToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Company",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Company");
        }
    }
}
