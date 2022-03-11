using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Infra.Migrations
{
    public partial class UpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ArduinoAction",
                newName: "InsertedDate");

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "ArduinoAction",
                newName: "ExecutionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertedDate",
                table: "ArduinoAction",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "ExecutionDate",
                table: "ArduinoAction",
                newName: "InsertDate");
        }
    }
}
