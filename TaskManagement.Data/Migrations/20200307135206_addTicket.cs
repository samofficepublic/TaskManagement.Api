using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Data.Migrations
{
    public partial class addTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<long>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<long>(nullable: true),
                    Subject = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
