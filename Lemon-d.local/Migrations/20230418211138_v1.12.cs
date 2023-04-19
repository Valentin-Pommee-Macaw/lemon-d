using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lemon_d.local.Migrations
{
    /// <inheritdoc />
    public partial class v112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalRating_Note_NoteID",
                table: "PersonalRating");

            migrationBuilder.DropIndex(
                name: "IX_PersonalRating_NoteID",
                table: "PersonalRating");

            migrationBuilder.DropColumn(
                name: "NoteID",
                table: "PersonalRating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NoteID",
                table: "PersonalRating",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRating_NoteID",
                table: "PersonalRating",
                column: "NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalRating_Note_NoteID",
                table: "PersonalRating",
                column: "NoteID",
                principalTable: "Note",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
