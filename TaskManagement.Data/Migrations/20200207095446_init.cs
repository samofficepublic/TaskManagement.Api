using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<long>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<long>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Password = table.Column<string>(maxLength: 300, nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
