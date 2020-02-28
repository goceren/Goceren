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

    public class AdminMediumController : Controller
    {
        private readonly IMediumpageService _mediumpageService;
        public AdminMediumController(IMediumpageService mediumpageService)
        {
            _mediumpageService = mediumpageService;
        }

        // List of Medium Page
        [Route("/admin/medium")]
        public IActionResult Index()
        {
            var model = _mediumpageService.GetAll();
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

        // Create Medium Page
        [Route("/admin/medium/create")]
        public IActionResult Create()
        {
            return View(new Mediumpage());
        }
        [HttpPost, Route("/admin/medium/create")]
        public async Task<IActionResult> CreateAsync(Mediumpage entity, IFormFile file, IFormFile filedetail)
        {
            if (file != null && file.ContentType.Contains("image"))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.BackgroundImage = file.FileName;
            }
            if (filedetail != null && filedetail.ContentType.Contains("image"))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", filedetail.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await filedetail.CopyToAsync(stream);
                }
                entity.DetailImage = filedetail.FileName;
            }
            if (ModelState.IsValid)
            {              
                _mediumpageService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Medium Sayfası başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // Edit Medium Page
        [Route("/admin/medium/edit/{id?}")]
        public IActionResult Edit(int mediumId)
        {
            return View(_mediumpageService.GetById(mediumId));
        }
        [HttpPost, Route("/admin/medium/edit/{id?}")]
        public async Task<IActionResult> Edit(Mediumpage entity, IFormFile file, IFormFile filedetail)
        {
            var model = _mediumpageService.GetById(entity.MediumpageId);
            if (file != null && file.ContentType.Contains("image"))
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
                entity.BackgroundImage = _mediumpageService.GetById(model.MediumpageId).BackgroundImage;
            }
            if (filedetail != null && filedetail.ContentType.Contains("image"))
            {
                var pathCV = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", filedetail.FileName);
                using (var streamCV = new FileStream(pathCV, FileMode.Create))
                {
                    await filedetail.CopyToAsync(streamCV);
                }
                entity.DetailImage = filedetail.FileName;
            }
            else
            {
                entity.DetailImage = _mediumpageService.GetById(model.MediumpageId).DetailImage;
            }
            if (ModelState.IsValid)
            {
                _mediumpageService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Medium Sayfası başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
            
        }

        // Delete Medium Page
        [Route("/admin/medium/delete/{id?}")]
        public IActionResult Delete(int mediumId)
        {
            return View(_mediumpageService.GetById(mediumId));
        }

        [HttpPost, ActionName("Delete"), Route("/admin/medium/delete/{id?}")]
        public IActionResult DeleteConfirmed(int mediumId)
        {
            var entity = _mediumpageService.GetById(mediumId);
            if (entity != null)
            {
                _mediumpageService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Medium Sayfası başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }
    }
}