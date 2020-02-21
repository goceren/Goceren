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
    [Migration("20200220140230_Viewerss")]
    partial class Viewerss
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BlogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BlogDetailImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogViewImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryType")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumepageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumepageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageSubtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .IsRequired()
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NavbarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NavbarTitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageSubtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftTopTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumepageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightTopTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteKeywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteTitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillTitle")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedinLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediumLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterLink")
                        .IsRequired()
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessTokenSecret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsumerKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsumerSecret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("TweetsId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("Goceren.Entities.Viewers", b =>
                {
                    b.Property<int>("ViewersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewBlog")
                        .HasColumnType("int");

                    b.HasKey("ViewersId");

                    b.ToTable("Viewers");
                });

            modelBuilder.Entity("Goceren.Entities.WhatIDo", b =>
                {
                    b.Property<int>("WhatIDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatIDoTitle")
                        .IsRequired()
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
