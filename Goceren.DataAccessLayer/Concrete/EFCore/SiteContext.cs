using Goceren.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer
{
    public class SiteContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>()
                .HasKey(c => new { c.CategoryId, c.BlogId });
            modelBuilder.Entity<HomeSubtitle>()
                .HasKey(d => new { d.HomepageId, d.SubtitleId });
        }
        public DbSet<Navbar> Navbar{ get; set; }
        public DbSet<Homepage> Homepage{ get; set; }
        public DbSet<Subtitle> Subtitle{ get; set; }
        public DbSet<Settings> Settings{ get; set; }
        public DbSet<Social> Social{ get; set; }
        public DbSet<WhatIDo> WhatIDo{ get; set; }
        public DbSet<Resumepage> Resumepage { get; set; }
        public DbSet<Education> Education{ get; set; }
        public DbSet<Experience> Experience{ get; set; }
        public DbSet<Skills> Skills{ get; set; }
        public DbSet<Tweets> Tweets { get; set; }
        public DbSet<Portfoliopage> Portfoliopage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Mediumpage> Mediumpage { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Blogpage> Blogpage { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuType> MenuType { get; set; }
        public DbSet<Viewers> Viewers { get; set; }
    }
}
