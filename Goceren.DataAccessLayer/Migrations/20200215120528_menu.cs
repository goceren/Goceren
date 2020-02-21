using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(nullable: true),
                    BlogContent = table.Column<string>(nullable: true),
                    BlogAuthor = table.Column<string>(nullable: true),
                    BlogDate = table.Column<DateTime>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    isPublished = table.Column<bool>(nullable: false),
                    BlogViewImage = table.Column<string>(nullable: true),
                    BlogDetailImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Blogpage",
                columns: table => new
                {
                    BlogpageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTitle = table.Column<string>(nullable: true),
                    PageSubtitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogpage", x => x.BlogpageId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryType = table.Column<string>(nullable: true),
                    isValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Homepage",
                columns: table => new
                {
                    HomepageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    AboutImage = table.Column<string>(nullable: true),
                    AboutTop = table.Column<string>(nullable: true),
                    AboutBottom = table.Column<string>(nullable: true),
                    CVLink = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homepage", x => x.HomepageId);
                });

            migrationBuilder.CreateTable(
                name: "Mediumpage",
                columns: table => new
                {
                    MediumpageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTitle = table.Column<string>(nullable: true),
                    PageSubtitle = table.Column<string>(nullable: true),
                    MediumUsername = table.Column<string>(nullable: true),
                    BackgroundImage = table.Column<string>(nullable: true),
                    DetailImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mediumpage", x => x.MediumpageId);
                });

            migrationBuilder.CreateTable(
                name: "MenuType",
                columns: table => new
                {
                    MenuTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuTypeName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuType", x => x.MenuTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Navbar",
                columns: table => new
                {
                    NavbarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NavbarTitle = table.Column<string>(nullable: true),
                    NavbarImage = table.Column<string>(nullable: true),
                    Cpyright = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navbar", x => x.NavbarId);
                });

            migrationBuilder.CreateTable(
                name: "Portfoliopage",
                columns: table => new
                {
                    PortfoliopageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTitle = table.Column<string>(nullable: true),
                    PageSubtitle = table.Column<string>(nullable: true),
                    GithubUsername = table.Column<string>(nullable: true),
                    BackgroundImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfoliopage", x => x.PortfoliopageId);
                });

            migrationBuilder.CreateTable(
                name: "Resumepage",
                columns: table => new
                {
                    ResumepageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumepageTitle = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    CVLink = table.Column<string>(nullable: true),
                    LeftTopTitle = table.Column<string>(nullable: true),
                    LeftBottomTitle = table.Column<string>(nullable: true),
                    RightTopTitle = table.Column<string>(nullable: true),
                    RightBottomTitle = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumepage", x => x.ResumepageId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteTitle = table.Column<string>(nullable: true),
                    SiteDescription = table.Column<string>(nullable: true),
                    SiteAuthor = table.Column<string>(nullable: true),
                    SiteKeywords = table.Column<string>(nullable: true),
                    SiteIcon = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsId);
                });

            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    SocialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacebookLink = table.Column<string>(nullable: true),
                    TwitterLink = table.Column<string>(nullable: true),
                    InstagramLink = table.Column<string>(nullable: true),
                    LinkedinLink = table.Column<string>(nullable: true),
                    GithubLink = table.Column<string>(nullable: true),
                    MediumLink = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.SocialId);
                });

            migrationBuilder.CreateTable(
                name: "Subtitle",
                columns: table => new
                {
                    SubtitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubtitleName = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtitle", x => x.SubtitleId);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    TweetsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerKey = table.Column<string>(nullable: true),
                    ConsumerSecret = table.Column<string>(nullable: true),
                    AccessToken = table.Column<string>(nullable: true),
                    AccessTokenSecret = table.Column<string>(nullable: true),
                    FeedTitle = table.Column<string>(nullable: true),
                    TwitterUsername = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.TweetsId);
                });

            migrationBuilder.CreateTable(
                name: "WhatIDo",
                columns: table => new
                {
                    WhatIDoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhatIDoTitle = table.Column<string>(nullable: true),
                    Title1 = table.Column<string>(nullable: true),
                    Description1 = table.Column<string>(nullable: true),
                    Title2 = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatIDo", x => x.WhatIDoId);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => new { x.CategoryId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_BlogCategory_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(nullable: true),
                    MenuLink = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false),
                    MenuTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menu_MenuType_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "MenuType",
                        principalColumn: "MenuTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumepageId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EducationType = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Education_Resumepage_ResumepageId",
                        column: x => x.ResumepageId,
                        principalTable: "Resumepage",
                        principalColumn: "ResumepageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumepageId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experience_Resumepage_ResumepageId",
                        column: x => x.ResumepageId,
                        principalTable: "Resumepage",
                        principalColumn: "ResumepageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumepageId = table.Column<int>(nullable: false),
                    SkillTitle = table.Column<string>(nullable: true),
                    SkillPercent = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
                    table.ForeignKey(
                        name: "FK_Skills_Resumepage_ResumepageId",
                        column: x => x.ResumepageId,
                        principalTable: "Resumepage",
                        principalColumn: "ResumepageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeSubtitle",
                columns: table => new
                {
                    HomepageId = table.Column<int>(nullable: false),
                    SubtitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSubtitle", x => new { x.HomepageId, x.SubtitleId });
                    table.ForeignKey(
                        name: "FK_HomeSubtitle_Homepage_HomepageId",
                        column: x => x.HomepageId,
                        principalTable: "Homepage",
                        principalColumn: "HomepageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeSubtitle_Subtitle_SubtitleId",
                        column: x => x.SubtitleId,
                        principalTable: "Subtitle",
                        principalColumn: "SubtitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory_BlogId",
                table: "BlogCategory",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_ResumepageId",
                table: "Education",
                column: "ResumepageId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ResumepageId",
                table: "Experience",
                column: "ResumepageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSubtitle_SubtitleId",
                table: "HomeSubtitle",
                column: "SubtitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuTypeId",
                table: "Menu",
                column: "MenuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ResumepageId",
                table: "Skills",
                column: "ResumepageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategory");

            migrationBuilder.DropTable(
                name: "Blogpage");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "HomeSubtitle");

            migrationBuilder.DropTable(
                name: "Mediumpage");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Navbar");

            migrationBuilder.DropTable(
                name: "Portfoliopage");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Social");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "WhatIDo");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Homepage");

            migrationBuilder.DropTable(
                name: "Subtitle");

            migrationBuilder.DropTable(
                name: "MenuType");

            migrationBuilder.DropTable(
                name: "Resumepage");
        }
    }
}
