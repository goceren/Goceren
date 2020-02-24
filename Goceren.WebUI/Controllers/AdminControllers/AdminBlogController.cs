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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Goceren.WebUI.Controllers.AdminControllers
{
    [Authorize(Roles = "admin")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogpageService _blogpageService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogCategoryService _blogcategoryService;
        public AdminBlogController(ICategoryService categoryService, IBlogService blogService, IBlogpageService blogpageService, IBlogCategoryService blogcategoryService)
        {
            _blogpageService = blogpageService;
            _blogService = blogService;
            _categoryService = categoryService;
            _blogcategoryService = blogcategoryService;
        }
        // ----------------------------------------------------------BLOGPAGE -----------------------------------------------------------
        // Blogpages 
        [Route("/admin/blogpage")]
        public IActionResult Index()
        {
            var model = _blogpageService.GetAll();
            ViewBag.items = model.Where(i => i.isApproved == true).Count();
            if (ViewBag.items == 1)
            {
                ViewBag.alert = false;
            }
            else
            {
                ViewBag.alert = true;
            }
            return View(model);
        }
        // Create Blogpage
        [Route("/admin/blogpage/create")]
        public IActionResult Create()
        {
            return View(new Blogpage());
        }
        [HttpPost, Route("/admin/blogpage/create")]
        public IActionResult Create(Blogpage entity)
        {
            if (ModelState.IsValid)
            {
                _blogpageService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Blog Sayfası başarıyla oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // Edit Blog Page
        [Route("/admin/blogpage/edit/{id?}")]
        public IActionResult Edit(int blogpageId)
        {
            return View(_blogpageService.GetById(blogpageId));
        }
        [HttpPost, Route("/admin/blogpage/edit/{id?}")]
        public IActionResult Edit(Blogpage model)
        {
            if (ModelState.IsValid)
            {
                _blogpageService.Update(model);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Blog Sayfası başarıyla güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete Blog Page
        [Route("/admin/blogpage/delete/{id?}")]
        public IActionResult Delete(int blogpageId)
        {
            return View(_blogpageService.GetById(blogpageId));
        }

        [HttpPost, ActionName("Delete"), Route("/admin/blogpage/delete/{id?}")]
        public IActionResult DeleteConfirmed(int blogpageId)
        {
            var entity = _blogpageService.GetById(blogpageId);
            if (entity != null)
            {
                _blogpageService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Blog Sayfası başarıyla silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }

        // ---------------------------------------------------------- BLOG -----------------------------------------------------------

        // Blogs
        [Route("/admin/blog")]
        public IActionResult Blog(string userName)
        {
            ViewBag.count = _blogService.GetAllWithCategory().Where(i => i.isPublished == true && i.BlogUser == true && i.SawAdmin == false).ToList().Count();
            if (string.IsNullOrEmpty(userName))
            {
                return View(_blogService.GetAllWithCategory().Where(i => i.BlogConfirm == true));
            }
            return View(_blogService.GetAllWithCategory().Where(i => i.BlogConfirm == true && i.UserName == userName));
        }

        // Create Blog
        [Route("/admin/blog/create")]
        public IActionResult CreateBlog()
        {
            return View(new Blog());
        }
        [HttpPost, Route("/admin/blog/create")]
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
        [Route("/admin/blog/edit/{id?}")]
        public IActionResult EditBlog(int blogId)
        {
            ViewBag.categories = _categoryService.GetAll().Where(i => i.CategoryType == "Blog").ToList();
            return View(_blogService.GetBlogDetails(blogId));
        }
        [HttpPost, Route("/admin/blog/edit/{id?}")]
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

        [Route("/admin/blog/delete/{id?}")]
        public IActionResult DeleteBlog(int blogId)
        {
            return View(_blogService.GetById(blogId));
        }

        [HttpPost, ActionName("DeleteBlog"), Route("/admin/blog/delete/{id?}")]
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

        // ---------------------------------------------------------- CATEGORIES -----------------------------------------------------------

        // List of categories
        [Route("/admin/blog/categories")]
        public IActionResult Categories()
        {
            var model = _categoryService.GetAll().Where(i => i.CategoryType == "Blog");
            ViewBag.items = model.Where(i => i.isApproved == true).Count();
            if (ViewBag.items == 1)
            {
                ViewBag.alert = false;
            }
            else
            {
                ViewBag.alert = true;
            }
            return View(model);
        }

        // Create category for Blog
        [Route("/admin/blog/category/create")]
        public IActionResult CreateCategory()
        {
            return View(new Category());
        }
        [HttpPost, Route("/admin/blog/category/create")]
        public IActionResult CreateCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Kategori başarıyla oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Categories");
            }
            return View(entity);
        }

        // Edit Category
        [Route("/admin/blog/category/edit/{id?}")]
        public IActionResult EditCategory(int categoryId)
        {
            return View(_categoryService.GetById(categoryId));
        }
        [HttpPost, Route("/admin/blog/category/edit/{id?}")]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Kategori başarıyla güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Categories");
            }
            return View(entity);
        }

        // Delete Category
        [Route("/admin/blog/category/delete/{id?}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            return View(_categoryService.GetById(categoryId));
        }
        [HttpPost, ActionName("DeleteCategory"), Route("/admin/blog/category/delete/{id?}")]
        public IActionResult ConfirmedDeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            var blogcategories = _blogcategoryService.GetAll().Where(i => i.CategoryId == categoryId).ToList();
            if (entity != null)
            {
                if (blogcategories != null)
                {
                    foreach (var item in blogcategories)
                    {
                        _blogcategoryService.Delete(item);
                    }
                }
                _categoryService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Kategori başarıyla silindi.",
                Css = "success"
            });
            return RedirectToAction("Categories");
        }


        // ---------------------------------------------------------- USER BLOGS -----------------------------------------------------------



        // Users Blogs
        [Route("/admin/users/blog")]
        public IActionResult UserBlogs()
        {
            return View(_blogService.GetAllWithCategory().Where(i => i.BlogUser == true && i.isPublished == true));
        }

        // Edit Users Blog
        [Route("/admin/users/blog/edit/{id?}")]
        public IActionResult EditUserBlog(int blogId)
        {
            ViewBag.categories = _categoryService.GetAll().Where(i => i.CategoryType == "Blog").ToList();
            var model = _blogService.GetBlogDetails(blogId);
            if (model != null)
            {
                model.SawAdmin = true;
                _blogService.Update(model);
            }
            return View(model);
        }
        [HttpPost, Route("/admin/users/blog/edit/{id?}")]
        public async Task<IActionResult> EditUserBlog(Blog entity, IFormFile file, IFormFile fileTwo, int[] categoryId)
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
                entity.SawAdmin = true;
                _blogService.Update(entity, categoryId);
                ViewBag.categories = _categoryService.GetAll().Where(i => i.CategoryType == "Blog").ToList();
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Blog başarıyla güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("UserBlogs");
            }
            return View(entity);

        }

        // Delete Users Blog

        [Route("/admin/users/blog/delete/{id?}")]
        public IActionResult DeleteUserBlog(int blogId)
        {
            return View(_blogService.GetById(blogId));
        }

        [HttpPost, ActionName("DeleteUserBlog"), Route("/admin/users/blog/delete/{id?}")]
        public IActionResult DeleteConfirmedUserBlog(int blogId)
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
            return RedirectToAction("UserBlogs");
        }
    }
}