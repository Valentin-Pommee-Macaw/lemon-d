using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lemon_d.local.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageRating = table.Column<int>(type: "int", nullable: false),
                    MostWantedID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FavouriteID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AverageCompletion = table.Column<int>(type: "int", nullable: true),
                    CurrentlyPlayingID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlatformsOwnedID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lists_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Note_Lists_ProjectListID",
                        column: x => x.ProjectListID,
                        principalTable: "Lists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PersonalRating",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    NoteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalRating_Note_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Note",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformsID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreferredPlatformID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Platforms_Platform_PreferredPlatformID",
                        column: x => x.PreferredPlatformID,
                        principalTable: "Platform",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlugDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlobalRating = table.Column<int>(type: "int", nullable: false),
                    PersonalRatingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlannedFor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    VoteForRemoval = table.Column<bool>(type: "bit", nullable: false),
                    PlayerAmount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiantID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Lists_ProjectListID",
                        column: x => x.ProjectListID,
                        principalTable: "Lists",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_PersonalRating_PersonalRatingID",
                        column: x => x.PersonalRatingID,
                        principalTable: "PersonalRating",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Platforms_PlatformsID",
                        column: x => x.PlatformsID,
                        principalTable: "Platforms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_Projects_GiantID",
                        column: x => x.GiantID,
                        principalTable: "Projects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tag_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserCompletion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Completion = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompletion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCompletion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompletion_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentlyPlayingID",
                table: "AspNetUsers",
                column: "CurrentlyPlayingID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteID",
                table: "AspNetUsers",
                column: "FavouriteID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MostWantedID",
                table: "AspNetUsers",
                column: "MostWantedID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlatformsOwnedID",
                table: "AspNetUsers",
                column: "PlatformsOwnedID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ProjectID",
                table: "Company",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ProjectID",
                table: "Genre",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProjectID",
                table: "Image",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_CreatedById",
                table: "Lists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Note_AuthorId",
                table: "Note",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ProjectID",
                table: "Note",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ProjectListID",
                table: "Note",
                column: "ProjectListID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRating_NoteID",
                table: "PersonalRating",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_PlatformsID",
                table: "Platform",
                column: "PlatformsID");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PreferredPlatformID",
                table: "Platforms",
                column: "PreferredPlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GiantID",
                table: "Projects",
                column: "GiantID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PersonalRatingID",
                table: "Projects",
                column: "PersonalRatingID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PlatformsID",
                table: "Projects",
                column: "PlatformsID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectListID",
                table: "Projects",
                column: "ProjectListID");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ProjectID",
                table: "Tag",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompletion_ProjectID",
                table: "UserCompletion",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompletion_UserId",
                table: "UserCompletion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Platforms_PlatformsOwnedID",
                table: "AspNetUsers",
                column: "PlatformsOwnedID",
                principalTable: "Platforms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_CurrentlyPlayingID",
                table: "AspNetUsers",
                column: "CurrentlyPlayingID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_FavouriteID",
                table: "AspNetUsers",
                column: "FavouriteID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_MostWantedID",
                table: "AspNetUsers",
                column: "MostWantedID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Projects_ProjectID",
                table: "Company",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Projects_ProjectID",
                table: "Genre",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Projects_ProjectID",
                table: "Image",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Projects_ProjectID",
                table: "Note",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Platform_Platforms_PlatformsID",
                table: "Platform",
                column: "PlatformsID",
                principalTable: "Platforms",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_CreatedById",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_AuthorId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Platform_Platforms_PlatformsID",
                table: "Platform");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Platforms_PlatformsID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Projects_ProjectID",
                table: "Note");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "UserCompletion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PersonalRating");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Lists");
        }
    }
}
