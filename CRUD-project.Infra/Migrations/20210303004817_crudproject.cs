using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_project.Infra.Migrations
{
    public partial class crudproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false),
                    Sexo = table.Column<string>(maxLength: 30, nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Hobby = table.Column<string>(maxLength: 1000, nullable: false),
                    Datanascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desenvolvedores");
        }
    }
}
