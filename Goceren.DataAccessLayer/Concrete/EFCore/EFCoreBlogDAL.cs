using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreBlogDAL : EFCoreGenericRepository<Blog, SiteContext>, IBlogDAL
    {
        public List<Blog> GetAllWithCategory()
        {
            List<Blog> blogList = new List<Blog>();
            using (var context = new SiteContext())
            {
                var Blogs = context.Blog.AsQueryable();
                
                    Blogs = Blogs.Include(i => i.BlogCategories).ThenInclude(i => i.Category);
                
                return Blogs.ToList();                
            }
        }

        public Blog GetBlogDetails(int id)
        {
            using (var context = new SiteContext())
            {
                return context.Blog.Where(i => i.BlogId == id).Include(i => i.BlogCategories).ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public List<Blog> GetBlogsByCategory(string category)
        {
            using (var context = new SiteContext())
            {
                var Blogs = context.Blog.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    Blogs = Blogs.Include(i => i.BlogCategories).ThenInclude(i => i.Category).Where(i => i.BlogCategories.Any(a => a.Category.CategoryName.ToLower() == category.ToLower()));
                }
                return Blogs.ToList();
            }
        }

        public void Update(Blog entity, int[] id)
        {
            using (var context = new SiteContext())
            {
                var blog = context.Blog
                                   .Include(i => i.BlogCategories)
                                   .FirstOrDefault(i => i.BlogId == entity.BlogId);

                if (blog != null)
                {
                    blog.BlogTitle = entity.BlogTitle;
                    blog.BlogContent = entity.BlogContent;
                    blog.BlogAuthor = entity.BlogAuthor;
                    blog.BlogDate = entity.BlogDate;
                    blog.BlogDetailImage = entity.BlogDetailImage;
                    blog.BlogViewImage = entity.BlogViewImage;
                    blog.isPublished = entity.isPublished;
                    blog.ViewCount = entity.ViewCount;
                    blog.BlogCategories = id.Select(catid => new BlogCategory()
                    {
                        BlogId = entity.BlogId,
                        CategoryId = catid
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}
