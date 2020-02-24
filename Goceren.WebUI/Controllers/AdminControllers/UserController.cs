using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.Entities;
using Goceren.WebUI.Extensions;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goceren.WebUI.Controllers.AdminControllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogCategoryService _blogcategoryService;


        public UserController(IBlogService blogService, ICategoryService categoryService, IBlogCategoryService blogcategoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _blogcategoryService = blogcategoryService;

        }
        [Route("/user")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/user/blog")]
        public IActionResult Blog()
        {
            return View(_blogService.GetAllWithCategory().Where(i => i.BlogUser == true && i.UserName == User.Identity.Name).ToList());
        }
        [Route("user/blog/create")]
        public IActionResult CreateBlog()
        {
            return View(new Blog());
        }
        [HttpPost,Route("user/blog/create")]
        public async Task<IActionResult> CreateBlogAsync(Blog entity, IFormFile file, IFormFile fileTwo)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img\\Blog", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.BlogViewImage = file.FileName;
            }
            if (fileTwo != null)
            {
                var pathCV = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img\\Blog", fileTwo.FileName);
                using (var streamCV = new FileStream(pathCV, FileMode.Create))
                {
                    await fileTwo.CopyToAsync(streamCV);
                }
                entity.BlogDetailImage = fileTwo.FileName;
            }
            if (ModelState.IsValid)
            {
                _blogService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Blog başarıyla oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Blog");
            }
            return View(entity);
        }

        // Edit Blog
        [Route("/user/blog/edit/{id?}")]
        public IActionResult EditBlog(int blogId)
        {
            ViewBag.categories = _categoryService.GetAll().Where(i => i.CategoryType == "Blog").ToList();
            return View(_blogService.GetBlogDetails(blogId));
        }
        [HttpPost, Route("/user/blog/edit/{id?}")]
        public async Task<IActionResult> EditBlogAsync(Blog entity, IFormFile file, IFormFile fileTwo, int[] categoryId)
        {
            var blogs = _blogService.GetById(entity.BlogId);
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img\\Blog", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.BlogViewImage = file.FileName;
            }
            else
            {
                entity.BlogViewImage = blogs.BlogViewImage;
            }
            if (fileTwo != null)
            {
                var pathCV = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img\\Blog", fileTwo.FileName);
                using (var streamCV = new FileStream(pathCV, FileMode.Create))
                {
                    await fileTwo.CopyToAsync(streamCV);
                }
                entity.BlogDetailImage = fileTwo.FileName;
            }
            else
            {
                entity.BlogDetailImage = blogs.BlogDetailImage;
            }
            if (ModelState.IsValid)
            {
                _blogService.Update(entity, categoryId);
                ViewBag.categories = _categoryService.GetAll().Where(i => i.CategoryType == "Blog").ToList();
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Blog başarıyla güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Blog");
            }
            return View(entity);

        }

        // Delete Blog

        [Route("/user/blog/delete/{id?}")]
        public IActionResult DeleteBlog(int blogId)
        {
            return View(_blogService.GetById(blogId));
        }

        [HttpPost, ActionName("DeleteBlog"), Route("/user/blog/delete/{id?}")]
        public IActionResult DeleteConfirmedBlog(int blogId)
        {
            var entity = _blogService.GetById(blogId);
            var blogcategories = _blogcategoryService.GetAll().Where(i => i.BlogId == blogId).ToList();
            if (entity != null)
            {
                if (blogcategories != null)
                {
                    foreach (var item in blogcategories)
                    {
                        _blogcategoryService.Delete(item);
                    }
                }
                _blogService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Blog başarıyla silindi.",
                Css = "success"
            });
            return RedirectToAction("Blog");
        }
    }
}