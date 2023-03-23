using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaApi.Infra.Data.Migrations
{
    public partial class UpdateDatasStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Students",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentsContact",
                table: "Students",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsContact",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Observations",
                keyValue: null,
                column: "Observations",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Students",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
