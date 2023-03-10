using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaApi.Infra.Data.Migrations
{
    public partial class CreateColumnObservationsInStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observations",
                table: "Students",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observations",
                table: "Students");
        }
    }
}
