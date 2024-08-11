using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarKindred.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseNumber = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    ReleaseMonth = table.Column<int>(type: "int", nullable: false),
                    IsDark = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastMissionCompletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastAttackedGiant = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUsedRallyingStandard = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailVerifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Passphrase = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color_Hue = table.Column<int>(type: "int", nullable: false),
                    Color_Saturation = table.Column<int>(type: "int", nullable: false),
                    Color_Luminosity = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VassalTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Portrait = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Element = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Species = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sign = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VassalTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alliances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastActiveOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alliances_Users_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViewedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementViews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LastHarvestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PowerLastActivatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decorations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decorations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decorations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiantContributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttackDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiantContributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiantContributions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goodies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimedMissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Element = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Treasure = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Weapon = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StartedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CompletesOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimedMissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimedMissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CanDecorate = table.Column<bool>(type: "bit", nullable: false),
                    NextRumor = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastGoodie = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treasures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdventures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdventures_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdventures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Technology = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResearches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Technology = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CompletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTechnologies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUnlockedAvatars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnlockedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUnlockedAvatars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUnlockedAvatars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVassalTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVassalTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVassalTags_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MaxDurability = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    PrimaryBonus = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SecondaryBonus = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdventureSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    PreviousStep = table.Column<int>(type: "int", nullable: true),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    MinVassals = table.Column<int>(type: "int", nullable: false),
                    MaxVassals = table.Column<int>(type: "int", nullable: false),
                    RequiredElement = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    Narrative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Treasure = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Decoration = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UnlockableAvatar = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RecruitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PinOverride = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdventureSteps_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdventureSteps_VassalTemplate_RecruitId",
                        column: x => x.RecruitId,
                        principalTable: "VassalTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AllianceLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AllianceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllianceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllianceLogs_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllianceRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanRecruit = table.Column<bool>(type: "bit", nullable: false),
                    CanKick = table.Column<bool>(type: "bit", nullable: false),
                    CanTrackGiants = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllianceRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllianceRanks_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllianceRecruitStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InviteCodeActive = table.Column<bool>(type: "bit", nullable: false),
                    InviteCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InviteCodeGeneratedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OpenInvitationActive = table.Column<bool>(type: "bit", nullable: false),
                    OpenInvitationMinLevel = table.Column<int>(type: "int", nullable: false),
                    OpenInvitationMaxLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllianceRecruitStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllianceRecruitStatuses_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartsOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Element = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giants_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLogTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLogTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLogTags_PersonalLogs_PersonalLogId",
                        column: x => x.PersonalLogId,
                        principalTable: "PersonalLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TownDecorations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false),
                    FlipX = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownDecorations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TownDecorations_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdventureStepCompleted",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdventureStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdventureStepCompleted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdventureStepCompleted_AdventureSteps_AdventureStepId",
                        column: x => x.AdventureStepId,
                        principalTable: "AdventureSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdventureStepCompleted_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdventureStepInProgress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdventureStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CompletesOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdventureStepInProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdventureStepInProgress_AdventureSteps_AdventureStepId",
                        column: x => x.AdventureStepId,
                        principalTable: "AdventureSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdventureStepInProgress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAlliances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceRankId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JoinedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAlliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAlliances_AllianceRanks_AllianceRankId",
                        column: x => x.AllianceRankId,
                        principalTable: "AllianceRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserAlliances_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAlliances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vassals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimedMissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserAdventureStepInProgressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Portrait = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Willpower = table.Column<int>(type: "int", nullable: false),
                    RetirementPoints = table.Column<int>(type: "int", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    Element = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Species = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sign = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vassals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vassals_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vassals_TimedMissions_TimedMissionId",
                        column: x => x.TimedMissionId,
                        principalTable: "TimedMissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vassals_UserAdventureStepInProgress_UserAdventureStepInProgressId",
                        column: x => x.UserAdventureStepInProgressId,
                        principalTable: "UserAdventureStepInProgress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vassals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vassals_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelationshipVassal",
                columns: table => new
                {
                    RelationshipsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VassalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipVassal", x => new { x.RelationshipsId, x.VassalsId });
                    table.ForeignKey(
                        name: "FK_RelationshipVassal_Relationships_RelationshipsId",
                        column: x => x.RelationshipsId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationshipVassal_Vassals_VassalsId",
                        column: x => x.VassalsId,
                        principalTable: "Vassals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusEffects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VassalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusEffects_Vassals_VassalId",
                        column: x => x.VassalId,
                        principalTable: "Vassals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TownLeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VassalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownLeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TownLeaders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownLeaders_Vassals_VassalId",
                        column: x => x.VassalId,
                        principalTable: "Vassals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserVassalTagVassal",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VassalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVassalTagVassal", x => new { x.TagsId, x.VassalsId });
                    table.ForeignKey(
                        name: "FK_UserVassalTagVassal_UserVassalTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "UserVassalTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVassalTagVassal_Vassals_VassalsId",
                        column: x => x.VassalsId,
                        principalTable: "Vassals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_ReleaseNumber",
                table: "Adventures",
                column: "ReleaseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_ReleaseYear_ReleaseMonth",
                table: "Adventures",
                columns: new[] { "ReleaseYear", "ReleaseMonth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_Title",
                table: "Adventures",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdventureSteps_AdventureId_Step",
                table: "AdventureSteps",
                columns: new[] { "AdventureId", "Step" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdventureSteps_RecruitId",
                table: "AdventureSteps",
                column: "RecruitId");

            migrationBuilder.CreateIndex(
                name: "IX_AllianceLogs_AllianceId",
                table: "AllianceLogs",
                column: "AllianceId");

            migrationBuilder.CreateIndex(
                name: "IX_AllianceLogs_CreatedOn",
                table: "AllianceLogs",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AllianceRanks_AllianceId",
                table: "AllianceRanks",
                column: "AllianceId");

            migrationBuilder.CreateIndex(
                name: "IX_AllianceRecruitStatuses_AllianceId",
                table: "AllianceRecruitStatuses",
                column: "AllianceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alliances_CreatedOn",
                table: "Alliances",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alliances_LastActiveOn",
                table: "Alliances",
                column: "LastActiveOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alliances_LeaderId",
                table: "Alliances",
                column: "LeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CreatedOn",
                table: "Announcements",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementViews_UserId",
                table: "AnnouncementViews",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_Position",
                table: "Buildings",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_UserId",
                table: "Buildings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_Type",
                table: "Decorations",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_UserId",
                table: "Decorations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GiantContributions_UserId",
                table: "GiantContributions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Giants_AllianceId",
                table: "Giants",
                column: "AllianceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goodies_UserId",
                table: "Goodies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicLogins_UserId",
                table: "MagicLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserId",
                table: "Missions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLogs_CreatedOn",
                table: "PersonalLogs",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLogs_UserId",
                table: "PersonalLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLogTags_PersonalLogId",
                table: "PersonalLogTags",
                column: "PersonalLogId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipVassal_VassalsId",
                table: "RelationshipVassal",
                column: "VassalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_UserId",
                table: "Resources",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_UserId_Type",
                table: "Resources",
                columns: new[] { "UserId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusEffects_VassalId",
                table: "StatusEffects",
                column: "VassalId");

            migrationBuilder.CreateIndex(
                name: "IX_TimedMissions_UserId",
                table: "TimedMissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TownDecorations_TownId",
                table: "TownDecorations",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_TownLeaders_UserId_Position",
                table: "TownLeaders",
                columns: new[] { "UserId", "Position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TownLeaders_VassalId",
                table: "TownLeaders",
                column: "VassalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Towns_UserId",
                table: "Towns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treasures_UserId",
                table: "Treasures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventures_AdventureId",
                table: "UserAdventures",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventures_UserId",
                table: "UserAdventures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventureStepCompleted_AdventureStepId",
                table: "UserAdventureStepCompleted",
                column: "AdventureStepId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventureStepCompleted_UserId",
                table: "UserAdventureStepCompleted",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventureStepInProgress_AdventureStepId",
                table: "UserAdventureStepInProgress",
                column: "AdventureStepId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventureStepInProgress_UserId",
                table: "UserAdventureStepInProgress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlliances_AllianceId",
                table: "UserAlliances",
                column: "AllianceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlliances_AllianceRankId",
                table: "UserAlliances",
                column: "AllianceRankId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlliances_UserId",
                table: "UserAlliances",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserResearches_UserId_Technology",
                table: "UserResearches",
                columns: new[] { "UserId", "Technology" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastMissionCompletedOn",
                table: "Users",
                column: "LastMissionCompletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_EndDate",
                table: "UserSubscriptions",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_StartDate",
                table: "UserSubscriptions",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_UserId",
                table: "UserSubscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechnologies_UserId_Technology",
                table: "UserTechnologies",
                columns: new[] { "UserId", "Technology" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserUnlockedAvatars_UnlockedOn",
                table: "UserUnlockedAvatars",
                column: "UnlockedOn");

            migrationBuilder.CreateIndex(
                name: "IX_UserUnlockedAvatars_UserId",
                table: "UserUnlockedAvatars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVassalTags_Title",
                table: "UserVassalTags",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_UserVassalTags_UserId_Title",
                table: "UserVassalTags",
                columns: new[] { "UserId", "Title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserVassalTagVassal_VassalsId",
                table: "UserVassalTagVassal",
                column: "VassalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_Favorite",
                table: "Vassals",
                column: "Favorite");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_Level",
                table: "Vassals",
                column: "Level");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_MissionId",
                table: "Vassals",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_Name",
                table: "Vassals",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_TimedMissionId",
                table: "Vassals",
                column: "TimedMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_UserAdventureStepInProgressId",
                table: "Vassals",
                column: "UserAdventureStepInProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_UserId",
                table: "Vassals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vassals_WeaponId",
                table: "Vassals",
                column: "WeaponId",
                unique: true,
                filter: "[WeaponId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Level",
                table: "Weapons",
                column: "Level");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_UserId",
                table: "Weapons",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllianceLogs");

            migrationBuilder.DropTable(
                name: "AllianceRecruitStatuses");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AnnouncementViews");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Decorations");

            migrationBuilder.DropTable(
                name: "GiantContributions");

            migrationBuilder.DropTable(
                name: "Giants");

            migrationBuilder.DropTable(
                name: "Goodies");

            migrationBuilder.DropTable(
                name: "MagicLogins");

            migrationBuilder.DropTable(
                name: "PersonalLogTags");

            migrationBuilder.DropTable(
                name: "RelationshipVassal");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "StatusEffects");

            migrationBuilder.DropTable(
                name: "TownDecorations");

            migrationBuilder.DropTable(
                name: "TownLeaders");

            migrationBuilder.DropTable(
                name: "Treasures");

            migrationBuilder.DropTable(
                name: "UserAdventures");

            migrationBuilder.DropTable(
                name: "UserAdventureStepCompleted");

            migrationBuilder.DropTable(
                name: "UserAlliances");

            migrationBuilder.DropTable(
                name: "UserResearches");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "UserTechnologies");

            migrationBuilder.DropTable(
                name: "UserUnlockedAvatars");

            migrationBuilder.DropTable(
                name: "UserVassalTagVassal");

            migrationBuilder.DropTable(
                name: "PersonalLogs");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "AllianceRanks");

            migrationBuilder.DropTable(
                name: "UserVassalTags");

            migrationBuilder.DropTable(
                name: "Vassals");

            migrationBuilder.DropTable(
                name: "Alliances");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "TimedMissions");

            migrationBuilder.DropTable(
                name: "UserAdventureStepInProgress");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "AdventureSteps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "VassalTemplate");
        }
    }
}
