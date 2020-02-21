using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goceren.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogpageService _blogpageService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogCategoryService _blogcategoryService;
        private readonly IViewersService _viewersService;
        public BlogController(IBlogpageService blogpageService, IBlogService blogService, ICategoryService categoryService, IBlogCategoryService blogcategoryService, IViewersService viewersService)
        {
            _blogpageService = blogpageService;
            _blogService = blogService;
            _categoryService = categoryService;
            _blogcategoryService = blogcategoryService;
            _viewersService = viewersService;
        }
        public ActionResult Index(string category, string search)
        {
            BlogpageModels blogpageModel = new BlogpageModels();
            ViewBag.search = search;
            try
            {
                blogpageModel.Blogpage = _blogpageService.GetAll().Where(i => i.isApproved == true).FirstOrDefault();
                if (!string.IsNullOrEmpty(category))
                {
                    blogpageModel.Blogs = _blogService.GetBlogsByCategory(category).Where(i => i.isPublished == true).ToList();
                    ViewBag.Category = category;
                }
                else
                {
                    blogpageModel.Blogs = _blogService.GetAllWithCategory().Where(i => i.isPublished == true).OrderByDescending(d => d.BlogDate).ToList();
                    ViewBag.category = "All";
                }
                if (!string.IsNullOrEmpty(search))
                {
                    blogpageModel.Blogs = _blogService.GetAllWithCategory().Where(i => i.isPublished == true).Where(i => EF.Functions.Like(i.BlogTitle, "%" + search + "%") || EF.Functions.Like(i.BlogContent, "%" + search + "%")).OrderByDescending(d => d.BlogDate).ToList();
                }
                blogpageModel.Categories = _categoryService.GetAll().Where(i => i.CategoryType == "Blog" && i.isApproved == true).ToList();
            }
            catch (Exception)
            {
                blogpageModel.Blogpage = null;
            }
            return View(blogpageModel);
        }
        public ActionResult Detail(int BlogId)
        {
            BlogpageModels blogpageModel = new BlogpageModels();
            try
            {
                blogpageModel.Blog = _blogService.GetBlogDetails(BlogId);
                try
                {
                    blogpageModel.Categories = blogpageModel.Blog.BlogCategories.Select(i => i.Category).Where(i => i.isApproved == true).ToList();
                }
                catch (Exception)
                {
                    blogpageModel.Categories = null;
                }

            }
            catch (Exception)
            {
                blogpageModel.Blog = null;
                blogpageModel.Categories = null;
            }
            blogpageModel.Blogs = _blogService.GetAllWithCategory().Where(i => i.isPublished == true).ToList();

            var clientDetails = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                if (!(_viewersService.GetAll().Any(i => i.ViewBlog == BlogId && i.IP == clientDetails)))
                {

                    _viewersService.Create(new Viewers() { IP = clientDetails, ViewBlog = BlogId });
                    var blog = _blogService.GetById(BlogId);
                    blog.ViewCount++;
                    _blogService.Update(blog);
                }
            }
            catch (Exception)
            {
            }
            

            return View(blogpageModel);
        }

    }
}