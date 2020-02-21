using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.Business.Concrete;
using Goceren.DataAccessLayer.Abstract;
using Goceren.DataAccessLayer.Concrete;
using Goceren.DataAccessLayer.Concrete.EFCore;
using Goceren.WebUI.EmailServices;
using Goceren.WebUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Goceren.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {         
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Goceren.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<INavbarDAL, EFCoreNavbarDAL>();
            services.AddScoped<INavbarService, NavbarManager>();

            services.AddScoped<IHomepageDAL, EFCoreHomepageDAL>();
            services.AddScoped<IHomepageService, HomepageManager>();

            services.AddScoped<IMenuDAL, EFCoreMenuDAL>();
            services.AddScoped<IMenuService, MenuManager>();

            services.AddScoped<ISocialDAL, EFCoreSocialDAL>();
            services.AddScoped<ISocialService, SocialManager>();

            services.AddScoped<ISubtitleDAL, EFCoreSubtitleDAL>();
            services.AddScoped<ISubtitleService, SubtitleManager>();

            services.AddScoped<IWhatIDoDAL, EFCoreWhatIDoDAL>();
            services.AddScoped<IWhatIDoService, WhatIDoManager>();

            services.AddScoped<ISettingsDAL, EFCoreSettingsDAL>();
            services.AddScoped<ISettingsService, SettingsManager>();

            services.AddScoped<IResumepageDAL, EFCoreResumepageDAL>();
            services.AddScoped<IResumepageService, ResumepageManager>();

            services.AddScoped<IEducationDAL, EFCoreEducationDAL>();
            services.AddScoped<IEducationService, EducationManager>();

            services.AddScoped<ISkillsDAL, EFCoreSkillsDAL>();
            services.AddScoped<ISkillsService, SkillsManager>();

            services.AddScoped<IExperienceDAL, EFCoreExperienceDAL>();
            services.AddScoped<IExperienceService, ExperienceManager>();

            services.AddScoped<ITweetsDAL, EFCoreTweetsDAL>();
            services.AddScoped<ITweetsService, TweetsManager>();

            services.AddScoped<IPortfoliopageDAL, EFCorePortfoliopageDAL>();
            services.AddScoped<IPortfoliopageService, PortfoliopageManager>();

            services.AddScoped<ICategoryDAL, EFCoreCategoryDAL>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IMediumpageDAL, EFCoreMediumpageDAL>();
            services.AddScoped<IMediumpageService, MediumpageManager>();

            services.AddScoped<IBlogpageDAL, EFCoreBlogpageDAL>();
            services.AddScoped<IBlogpageService, BlogpageManager>();

            services.AddScoped<IBlogDAL, EFCoreBlogDAL>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<IBlogCategoryDAL, EFCoreBlogCategoryDAL>();
            services.AddScoped<IBlogCategoryService, BlogCategoryManager>();

            services.AddScoped<IHomeSubtitleDAL, EFCoreHomeSubtitleDAL>();
            services.AddScoped<IHomeSubtitleService, HomeSubtitleManager>();

            services.AddScoped<IMenuTypeDAL, EFCoreMenuTypeDAL>();
            services.AddScoped<IMenuTypeService, MenuTypeManager>();

            services.AddScoped<IViewersDAL, EFCoreViewersDAL>();
            services.AddScoped<IViewersService, ViewersManager>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //SeedDatabase.Seed();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}/{idextra?}");
            });

        }
    }
}
