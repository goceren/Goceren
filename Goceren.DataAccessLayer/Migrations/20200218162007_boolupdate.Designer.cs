﻿// <auto-generated />
using System;
using Goceren.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Goceren.DataAccessLayer.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20200218162007_boolupdate")]
    partial class boolupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Goceren.Entities.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BlogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BlogDetailImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogViewImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<bool>("isPublished")
                        .HasColumnType("bit");

                    b.HasKey("BlogId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Goceren.Entities.BlogCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "BlogId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("Goceren.Entities.Blogpage", b =>
                {
                    b.Property<int>("BlogpageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PageSubtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("BlogpageId");

                    b.ToTable("Blogpage");
                });

            modelBuilder.Entity("Goceren.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Goceren.Entities.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumepageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("EducationId");

                    b.HasIndex("ResumepageId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Goceren.Entities.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumepageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("ExperienceId");

                    b.HasIndex("ResumepageId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("Goceren.Entities.HomeSubtitle", b =>
                {
                    b.Property<int>("HomepageId")
                        .HasColumnType("int");

                    b.Property<int>("SubtitleId")
                        .HasColumnType("int");

                    b.HasKey("HomepageId", "SubtitleId");

                    b.HasIndex("SubtitleId");

                    b.ToTable("HomeSubtitle");
                });

            modelBuilder.Entity("Goceren.Entities.Homepage", b =>
                {
                    b.Property<int>("HomepageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutBottom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("HomepageId");

                    b.ToTable("Homepage");
                });

            modelBuilder.Entity("Goceren.Entities.Mediumpage", b =>
                {
                    b.Property<int>("MediumpageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediumUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageSubtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("MediumpageId");

                    b.ToTable("Mediumpage");
                });

            modelBuilder.Entity("Goceren.Entities.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("MenuId");

                    b.HasIndex("MenuTypeId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Goceren.Entities.MenuType", b =>
                {
                    b.Property<int>("MenuTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuTypeId");

                    b.ToTable("MenuType");
                });

            modelBuilder.Entity("Goceren.Entities.Navbar", b =>
                {
                    b.Property<int>("NavbarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NavbarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NavbarTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("NavbarId");

                    b.ToTable("Navbar");
                });

            modelBuilder.Entity("Goceren.Entities.Portfoliopage", b =>
                {
                    b.Property<int>("PortfoliopageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageSubtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("PortfoliopageId");

                    b.ToTable("Portfoliopage");
                });

            modelBuilder.Entity("Goceren.Entities.Resumepage", b =>
                {
                    b.Property<int>("ResumepageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftBottomTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftTopTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumepageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightTopTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("ResumepageId");

                    b.ToTable("Resumepage");
                });

            modelBuilder.Entity("Goceren.Entities.Settings", b =>
                {
                    b.Property<int>("SettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SiteAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("SettingsId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Goceren.Entities.Skills", b =>
                {
                    b.Property<int>("SkillsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResumepageId")
                        .HasColumnType("int");

                    b.Property<string>("SkillPercent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("SkillsId");

                    b.HasIndex("ResumepageId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Goceren.Entities.Social", b =>
                {
                    b.Property<int>("SocialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedinLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediumLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("SocialId");

                    b.ToTable("Social");
                });

            modelBuilder.Entity("Goceren.Entities.Subtitle", b =>
                {
                    b.Property<int>("SubtitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubtitleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("SubtitleId");

                    b.ToTable("Subtitle");
                });

            modelBuilder.Entity("Goceren.Entities.Tweets", b =>
                {
                    b.Property<int>("TweetsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessTokenSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsumerKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsumerSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("TweetsId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("Goceren.Entities.WhatIDo", b =>
                {
                    b.Property<int>("WhatIDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatIDoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("WhatIDoId");

                    b.ToTable("WhatIDo");
                });

            modelBuilder.Entity("Goceren.Entities.BlogCategory", b =>
                {
                    b.HasOne("Goceren.Entities.Blog", "Blog")
                        .WithMany("BlogCategories")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Goceren.Entities.Category", "Category")
                        .WithMany("BlogCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Goceren.Entities.Education", b =>
                {
                    b.HasOne("Goceren.Entities.Resumepage", "Resumepage")
                        .WithMany("Educations")
                        .HasForeignKey("ResumepageId");
                });

            modelBuilder.Entity("Goceren.Entities.Experience", b =>
                {
                    b.HasOne("Goceren.Entities.Resumepage", "Resumepage")
                        .WithMany("Experiences")
                        .HasForeignKey("ResumepageId");
                });

            modelBuilder.Entity("Goceren.Entities.HomeSubtitle", b =>
                {
                    b.HasOne("Goceren.Entities.Homepage", "Homepage")
                        .WithMany("HomeSubtitle")
                        .HasForeignKey("HomepageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Goceren.Entities.Subtitle", "Subtitle")
                        .WithMany("HomeSubtitle")
                        .HasForeignKey("SubtitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Goceren.Entities.Menu", b =>
                {
                    b.HasOne("Goceren.Entities.MenuType", "MenuType")
                        .WithMany("Menus")
                        .HasForeignKey("MenuTypeId");
                });

            modelBuilder.Entity("Goceren.Entities.Skills", b =>
                {
                    b.HasOne("Goceren.Entities.Resumepage", "Resumepage")
                        .WithMany("Skills")
                        .HasForeignKey("ResumepageId");
                });
#pragma warning restore 612, 618
        }
    }
}
