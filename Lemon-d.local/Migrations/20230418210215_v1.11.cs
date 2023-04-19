using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lemon_d.local.Migrations
{
    /// <inheritdoc />
    public partial class v111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlatformsID",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects",
                column: "PlatformsID",
                principalTable: "Platforms",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlatformsID",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects",
                column: "PlatformsID",
                principalTable: "Platforms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
