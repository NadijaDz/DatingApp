using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Infrastructure.Migrations
{
    public partial class LikeEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    SourceUserId = table.Column<int>(type: "int", nullable: false),
                    LikedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.SourceUserId, x.LikedUserId });
                    table.ForeignKey(
                        name: "FK_Likes_Users_LikedUserId",
                        column: x => x.LikedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Users_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "DateOfBirth", "LastActive" },
                values: new object[] { new DateTime(2021, 11, 5, 11, 59, 37, 85, DateTimeKind.Local).AddTicks(3470), new DateTime(2002, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 11, 59, 37, 85, DateTimeKind.Local).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "DateOfBirth", "LastActive" },
                values: new object[] { new DateTime(2021, 11, 5, 11, 59, 37, 85, DateTimeKind.Local).AddTicks(9501), new DateTime(2005, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 11, 59, 37, 85, DateTimeKind.Local).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "DateOfBirth", "LastActive" },
                values: new object[] { new DateTime(2021, 11, 5, 11, 59, 37, 85, DateTimeKind.Local).AddTicks(9792), new DateTime(2012, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 11, 59, 37, 85, DateTimeKind.Local).AddTicks(9795) });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedUserId",
                table: "Likes",
                column: "LikedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "DateOfBirth", "LastActive" },
                values: new object[] { new DateTime(2021, 11, 3, 8, 51, 5, 500, DateTimeKind.Local).AddTicks(9590), new DateTime(2018, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 3, 8, 51, 5, 501, DateTimeKind.Local).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "DateOfBirth", "LastActive" },
                values: new object[] { new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(6246), new DateTime(2014, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(6256) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "DateOfBirth", "LastActive" },
                values: new object[] { new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(7056), new DateTime(2002, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(7065) });
        }
    }
}
