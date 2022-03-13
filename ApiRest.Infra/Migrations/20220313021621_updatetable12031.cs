using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Infra.Migrations
{
    public partial class updatetable12031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ArduinoAction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ArduinoAction");
        }
    }
}
