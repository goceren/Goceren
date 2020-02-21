using Goceren.DataAccessLayer;
using Goceren.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new SiteContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Navbar.Count() == 0)
                {
                    context.Navbar.AddRange(Navbars);
                }
                if (context.Homepage.Count() == 0)
                {
                    context.Homepage.AddRange(Homepages);
                }
                if (context.Menu.Count() == 0)
                {
                    context.Menu.AddRange(Menus);
                }
                if (context.Social.Count() == 0)
                {
                    context.Social.AddRange(Socials);
                }

                if (context.WhatIDo.Count() == 0)
                {
                    context.WhatIDo.AddRange(WhatIDos);
                }
                if (context.Settings.Count() == 0)
                {
                    context.Settings.AddRange(Settings);
                }
                if (context.Resumepage.Count() == 0)
                {
                    context.Resumepage.AddRange(Resumepages);
                }

                if (context.Tweets.Count() == 0)
                {
                    context.Tweets.AddRange(Tweets);
                }
                if (context.Portfoliopage.Count() == 0)
                {
                    context.Portfoliopage.AddRange(Portfoliopages);
                }                
                if (context.Blogpage.Count() == 0)
                {
                    context.Blogpage.AddRange(Blogpages);
                }
                if (context.Mediumpage.Count() == 0)
                {
                    context.Mediumpage.AddRange(Mediumpages);
                }
                if (context.Category.Count() == 0)
                {
                    context.Category.AddRange(Category);
                }
                if (context.Blog.Count() == 0)
                {
                    context.Blog.AddRange(Blogs);
                    context.AddRange(BlogCategory);
                }
                if (context.Skills.Count() == 0)
                {
                    context.Skills.AddRange(Skills);
                }
                if (context.Education.Count() == 0)
                {
                    context.Education.AddRange(Educations);
                }
                if (context.Experience.Count() == 0)
                {
                    context.Experience.AddRange(Experiences);
                }
                context.SaveChanges();
            }
        }

        private static Navbar[] Navbars =
        {
            new Navbar() {NavbarTitle = "Veli Yavuz Göçeren", NavbarImage="Deneme", Cpyright="2020", isApproved=true }
        };
        private static Menu[] Menus =
        {
            new Menu() { MenuName="Home", MenuLink="Home", isApproved=true},
            new Menu() { MenuName="Resume", MenuLink="Resume",isApproved=true},
            new Menu() { MenuName="Portfolio", MenuLink="Portfolio",isApproved=true},
            new Menu() { MenuName="Blog", MenuLink="Blog",isApproved=true},
            new Menu() { MenuName="Contact", MenuLink="Contact",isApproved=true}
        };

        private static Homepage[] Homepages =
        {
            new Homepage() { Title="Veli Yavuz Göçeren", AboutTop="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. ", AboutBottom="1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", CVLink="https://goceren.com", AboutImage="deneme.jpg",isApproved=true }
        };

        private static Social[] Socials =
        {
            new Social() {TwitterLink="https://twitter.com/vygoceren", Email="vygoceren@gmail.com", FacebookLink="https://facebook.com/vygoceren", GithubLink="https://github.com/goceren", InstagramLink="https://instagram.com/vygoceren", LinkedinLink="https://linkedin.com/vygoceren",MediumLink="https://medium.com/vygoceren",isApproved=true  }
        };
           
        private static WhatIDo[] WhatIDos =
        {
            new WhatIDo() { WhatIDoTitle="What I Do", Title1="Title1", Description1="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.", Title2="Title2", Description2="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.", isApproved=true}
        };
        private static Settings[] Settings =
        {
            new Settings() { SiteAuthor="Veli Yavuz Göçeren", SiteDescription="Veli Yavuz Göçeren'in projelerini, yazılarını ve özgeçmişini paylaştığı kişisel web sitesi.", SiteIcon="vyg.png", SiteKeywords="Javascript, PHP, ASP.NET MVC, ASP.NET CORE, WEB API, WEB SERVICE, C#, JAVA, MOBILE, WEB, ANDROID, Veli Yavuz Göçeren", SiteTitle="Veli Yavuz Göçeren"}
        };

        private static Resumepage[] Resumepages =
        {
            new Resumepage() { ResumepageTitle="Resume Page", RightTopTitle="Educationss", LeftTopTitle = "Skilss", LeftBottomTitle="Skill2", CVLink="https://goceren.com", Subtitle="Veli Yavuz Göçeren", isApproved=true }
        };     
        private static Tweets[] Tweets =
        {
            new Tweets() {ConsumerKey="fdksh", ConsumerSecret="fdsf", AccessToken="dsaada", AccessTokenSecret="dsad", FeedTitle="Twitter Akışı", TwitterUsername="VYGoceren"}
        };
        private static Portfoliopage[] Portfoliopages =
        {
            new Portfoliopage() {PageTitle="Portfolio", PageSubtitle="Projelerim", GithubUsername="goceren", BackgroundImage="Github-logo.png"}
        };

        private static Mediumpage[] Mediumpages =
        {
            new Mediumpage() {PageTitle="Blog", MediumUsername="vygoceren", PageSubtitle="Yazılarım", BackgroundImage="deneme", DetailImage="VYGKpk.png"}
        };

        private static Blogpage[] Blogpages =
        {
            new Blogpage() {PageTitle="Blog", PageSubtitle="Yazılarım"}
        };
        private static Blog[] Blogs =
        {
            new Blog() {BlogTitle="Birinci Blog", BlogAuthor="Veli Yavuz Göçeren", BlogContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.", BlogDate=DateTime.Now, ViewCount=0, isPublished= true, BlogDetailImage="blog_post_1.jpg", BlogViewImage="blog_post_1_full.jpg"}
        };
        private static Category[] Category =
        {
            new Category() {CategoryName="JavaScript", CategoryType="Github", isApproved=true},
            new Category() {CategoryName="C#", CategoryType="Github", isApproved=true},
            new Category() {CategoryName="CSS", CategoryType="Github", isApproved=true},
            new Category() {CategoryName="Java", CategoryType="Github", isApproved=true},
            new Category() {CategoryName="JavaScript", CategoryType="Blog", isApproved=true},
            new Category() {CategoryName="C#", CategoryType="Blog", isApproved=true},
            new Category() {CategoryName="CSS", CategoryType="Blog", isApproved=true},
            new Category() {CategoryName="Java", CategoryType="Blog", isApproved=true}
        };

        private static Experience[] Experiences =
                {
            new Experience() { ResumepageId=1, Date="2019 - 2019", CompanyName="Kar Teknoloji", Title="Staj", Description="Stajımı Kayseri Teknoparkta bulunan Kar Teknoloji Yazılım şirketinde 4 ay gibi bir süre yaptım" ,isApproved=true },
            new Experience() { ResumepageId=1, Date="Current", CompanyName="Freelance", Title="Freelance", Description="Freelance olarak proje bazlı çalışmalara devam ediyorum.", isApproved=true }

        };

        private static Skills[] Skills =
        {
            new Skills() { ResumepageId=1, SkillTitle="HTML / CSS", SkillPercent="65", isApproved=true },
            new Skills() { ResumepageId=1, SkillTitle="JavaScript", SkillPercent="65", isApproved=true },
            new Skills() { ResumepageId=1, SkillTitle="C#", SkillPercent="95", isApproved=true },
            new Skills() { ResumepageId=1, SkillTitle="Java", SkillPercent="65", isApproved=true }
        };

        private static Education[] Educations =
        {
            new Education() { ResumepageId=1, Date="2010 - 2014", EducationType="High School", Title="Karaman Anatolian HighSchool", Description="Karaman'da 2010 2014 yılları arasında liseyi Karaman Anadolu Lisesinde Okudum.", isApproved=true },
            new Education() { ResumepageId=1, Date="2015 - Current", EducationType="Erciyes Üniversitesi", Title="Bilgisayar Mühendisliği", Description="Üniversiteyi Kayseride bulunan Erciyes Üniversitesinin mühendislik fakültesinde okudum.", isApproved=true }

        };

        
        private static BlogCategory[] BlogCategory =
        {
            new BlogCategory() { Blog = Blogs[0], Category = Category[0]},
            new BlogCategory() { Blog = Blogs[0], Category = Category[0]},
            new BlogCategory() { Blog = Blogs[0], Category = Category[2]}
        };

    }
}
