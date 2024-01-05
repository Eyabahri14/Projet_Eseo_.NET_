using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.DataAccessLayer.Migrations
{
    public partial class Division : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Division",
                table: "Citoyens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Division",
                table: "Citoyens");
        }
    }
}
