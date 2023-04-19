using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lemon_d.local.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Projects_GiantID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_GiantID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GiantID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PlayerAmount",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Projects",
                newName: "GameID");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerAmountID",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PlayerAmount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Singleplayer = table.Column<bool>(type: "bit", nullable: false),
                    OfflineCoop = table.Column<bool>(type: "bit", nullable: false),
                    LocalCoop = table.Column<bool>(type: "bit", nullable: false),
                    OnlineCoop = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAmount", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PlayerAmountID",
                table: "Projects",
                column: "PlayerAmountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects",
                column: "PlatformsID",
                principalTable: "Platforms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PlayerAmount_PlayerAmountID",
                table: "Projects",
                column: "PlayerAmountID",
                principalTable: "PlayerAmount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PlayerAmount_PlayerAmountID",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "PlayerAmount");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PlayerAmountID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PlayerAmountID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Projects",
                newName: "Discriminator");

            migrationBuilder.AddColumn<Guid>(
                name: "GiantID",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerAmount",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GiantID",
                table: "Projects",
                column: "GiantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects",
                column: "PlatformsID",
                principalTable: "Platforms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Projects_GiantID",
                table: "Projects",
                column: "GiantID",
                principalTable: "Projects",
                principalColumn: "ID");
        }
    }
}
