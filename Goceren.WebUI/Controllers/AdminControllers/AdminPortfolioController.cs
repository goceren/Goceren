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
    [Authorize(Roles = "admin")]

    public class AdminPortfolioController : Controller
    {
        private readonly IPortfoliopageService _portfoliopageService;
        private readonly ICategoryService _categoryService;
        public AdminPortfolioController(IPortfoliopageService portfoliopageService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _portfoliopageService = portfoliopageService;
        }


        // -------------------------------------------------------------- PORTFOLIO PAGE ---------------------------------------------------------------

        // List of portfolio pages
        [Route("/admin/portfolio")]
        public IActionResult Index()
        {
            var model = _portfoliopageService.GetAll();
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

        // Create portfolio page
        [Route("/admin/portfolio/create")]
        public IActionResult Create()
        {
            return View(new Portfoliopage());
        }
        [HttpPost, Route("/admin/portfolio/create")]
        public async Task<IActionResult> CreateAsync(Portfoliopage entity, IFormFile file)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.BackgroundImage = file.FileName;
            }
            if (ModelState.IsValid)
            {             
                _portfoliopageService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Projelerim Sayfası başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // Edit portfolio page 
        [Route("/admin/portfolio/edit/{id?}")]
        public IActionResult Edit(int portfolioId)
        {
            return View(_portfoliopageService.GetById(portfolioId));
        }
        [HttpPost, Route("/admin/portfolio/edit/{id?}")]
        public async Task<IActionResult> Edit(Portfoliopage entity, IFormFile file)
        {
            var model = _portfoliopageService.GetById(entity.PortfoliopageId);
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.BackgroundImage = file.FileName;
            }
            else
            {
                entity.BackgroundImage = model.BackgroundImage;
            }
            if (ModelState.IsValid)
            {
                _portfoliopageService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Projelerim Sayfası başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
            
        }

        // Delete portfolio page
        [Route("/admin/portfolio/delete/{id?}")]
        public IActionResult Delete(int portfolioId)
        {
            return View(_portfoliopageService.GetById(portfolioId));
        }
        [HttpPost, ActionName("Delete"), Route("/admin/portfolio/delete/{id?}")]
        public IActionResult ConfirmedDelete(int portfolioId)
        {
            var entity = _portfoliopageService.GetById(portfolioId);
            if (entity != null)
            {
                _portfoliopageService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Projelerim Sayfası başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }


        // -------------------------------------------------------------- CATEORIES ---------------------------------------------------------------

        // List of categories
        [Route("/admin/categories")]
        public IActionResult Categories()
        {
            var model = _categoryService.GetAll().Where(i => i.CategoryType == "Github");
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

        // Create category for Github repos (Portfolio page)
        [Route("/admin/category/create")]
        public IActionResult CreateCategory()
        {
            return View(new Category());
        }
        [HttpPost, Route("/admin/category/create")]
        public IActionResult CreateCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Kategori başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Categories");
            }
            return View(entity);
        }

        // Edit Category
        [Route("/admin/category/edit/{id?}")]
        public IActionResult EditCategory(int categoryId)
        {
            return View(_categoryService.GetById(categoryId));
        }
        [HttpPost, Route("/admin/category/edit/{id?}")]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Kategori başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Categories");
            }
            return View(entity);
        }

        // Delete Category
        [Route("/admin/category/delete/{id?}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            return View(_categoryService.GetById(categoryId));
        }
        [HttpPost, ActionName("DeleteCategory"), Route("/admin/category/delete/{id?}")]
        public IActionResult ConfirmedDeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Kategori başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Categories");
        }
    }
}