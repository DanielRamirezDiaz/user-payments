using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBusinesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserBusinessId = table.Column<int>(type: "int", nullable: false),
                    Ammount = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_UserBusinesses_UserBusinessId",
                        column: x => x.UserBusinessId,
                        principalTable: "UserBusinesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Lastname", "Name" },
                values: new object[] { 1, "DanielRamirezDiaz@outlook.com", "Ramírez", "Daniel" });

            migrationBuilder.InsertData(
                table: "UserBusinesses",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[] { 1, "Online Music Streaming Service", "Spotify", 1 });

            migrationBuilder.InsertData(
                table: "UserBusinesses",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[] { 2, "Small Ecommerce Site Subscription", "Amazon Prime", 1 });

            migrationBuilder.InsertData(
                table: "UserBusinesses",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[] { 3, "Power Company", "CFE", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserBusinessId",
                table: "Payments",
                column: "UserBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinesses_UserId",
                table: "UserBusinesses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "UserBusinesses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
