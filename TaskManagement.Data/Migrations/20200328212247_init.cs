using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessName = table.Column<string>(maxLength: 100, nullable: true),
                    AccessRoute = table.Column<string>(nullable: true),
                    AccessComponent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesses", x => x.Id);
                });

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
                    BirthDay = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    AccessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccesses_Accesses_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Accesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_AccessId",
                table: "UserAccesses",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserId",
                table: "UserAccesses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserAccesses");

            migrationBuilder.DropTable(
                name: "Accesses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
