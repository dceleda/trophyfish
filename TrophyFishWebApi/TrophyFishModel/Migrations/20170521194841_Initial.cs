using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrophyFish.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "CloudDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FisheryTypeDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisheryTypeDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FishStatusDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishStatusDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LureBaitDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LureBaitDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MethodDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrecipitationDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecipitationDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PressureChangeDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureChangeDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SpecieDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserStatusDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatusDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WaterLevelDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterLevelDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WindDirectionDict",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindDirectionDict", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    StatusID = table.Column<byte>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserStatusDict_StatusID",
                        column: x => x.StatusID,
                        principalTable: "UserStatusDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirTemp = table.Column<short>(nullable: true),
                    CatchDate = table.Column<DateTime>(nullable: false),
                    CloudID = table.Column<byte>(nullable: true),
                    CountryID = table.Column<byte>(nullable: false),
                    FisheryTypeID = table.Column<byte>(nullable: false),
                    Length = table.Column<short>(nullable: true),
                    LureBaitDesc = table.Column<string>(maxLength: 50, nullable: true),
                    LureBaitID = table.Column<byte>(nullable: true),
                    MethodID = table.Column<byte>(nullable: true),
                    MoonPhase = table.Column<byte>(nullable: true),
                    PrecipitationID = table.Column<byte>(nullable: true),
                    Pressure = table.Column<short>(nullable: true),
                    PressureChangeID = table.Column<byte>(nullable: true),
                    SpecieID = table.Column<byte>(nullable: false),
                    StatusID = table.Column<byte>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    WaterLevelID = table.Column<byte>(nullable: true),
                    WaterTemp = table.Column<short>(nullable: true),
                    Weight = table.Column<short>(nullable: true),
                    WindDirID = table.Column<byte>(nullable: true),
                    WindSpeed = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fish_CloudDict_CloudID",
                        column: x => x.CloudID,
                        principalTable: "CloudDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_CountryDict_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountryDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_FisheryTypeDict_FisheryTypeID",
                        column: x => x.FisheryTypeID,
                        principalTable: "FisheryTypeDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_LureBaitDict_LureBaitID",
                        column: x => x.LureBaitID,
                        principalTable: "LureBaitDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_MethodDict_MethodID",
                        column: x => x.MethodID,
                        principalTable: "MethodDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_PrecipitationDict_PrecipitationID",
                        column: x => x.PrecipitationID,
                        principalTable: "PrecipitationDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_PressureChangeDict_PressureChangeID",
                        column: x => x.PressureChangeID,
                        principalTable: "PressureChangeDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_SpecieDict_SpecieID",
                        column: x => x.SpecieID,
                        principalTable: "SpecieDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_FishStatusDict_StatusID",
                        column: x => x.StatusID,
                        principalTable: "FishStatusDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_WaterLevelDict_WaterLevelID",
                        column: x => x.WaterLevelID,
                        principalTable: "WaterLevelDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_WindDirectionDict_WindDirID",
                        column: x => x.WindDirID,
                        principalTable: "WindDirectionDict",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusID",
                table: "Users",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_CloudID",
                table: "Fish",
                column: "CloudID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_CountryID",
                table: "Fish",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_FisheryTypeID",
                table: "Fish",
                column: "FisheryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_LureBaitID",
                table: "Fish",
                column: "LureBaitID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_MethodID",
                table: "Fish",
                column: "MethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_PrecipitationID",
                table: "Fish",
                column: "PrecipitationID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_PressureChangeID",
                table: "Fish",
                column: "PressureChangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_SpecieID",
                table: "Fish",
                column: "SpecieID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_StatusID",
                table: "Fish",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_UserID",
                table: "Fish",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_WaterLevelID",
                table: "Fish",
                column: "WaterLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_WindDirID",
                table: "Fish",
                column: "WindDirID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Fish");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CloudDict");

            migrationBuilder.DropTable(
                name: "CountryDict");

            migrationBuilder.DropTable(
                name: "FisheryTypeDict");

            migrationBuilder.DropTable(
                name: "LureBaitDict");

            migrationBuilder.DropTable(
                name: "MethodDict");

            migrationBuilder.DropTable(
                name: "PrecipitationDict");

            migrationBuilder.DropTable(
                name: "PressureChangeDict");

            migrationBuilder.DropTable(
                name: "SpecieDict");

            migrationBuilder.DropTable(
                name: "FishStatusDict");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WaterLevelDict");

            migrationBuilder.DropTable(
                name: "WindDirectionDict");

            migrationBuilder.DropTable(
                name: "UserStatusDict");
        }
    }
}
