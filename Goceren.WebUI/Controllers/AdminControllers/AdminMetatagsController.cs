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

namespace Goceren.WebUI.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminMetatagsController : Controller
    {
        private readonly ISettingsService _settingsService;
        public AdminMetatagsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        // Metatags List 
        [Route("/admin/metatags")]
        public IActionResult Index()
        {
            var model = _settingsService.GetAll();
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

        // Create Metatag 
        [Route("/admin/metatag/create")]
        public IActionResult Create()
        {
            return View(new Settings());
        }
        [HttpPost, Route("/admin/metatag/create")]
        public async Task<IActionResult> Create(Settings entity, IFormFile file)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.SiteIcon = file.FileName;
            }
            if (ModelState.IsValid)
            {
                _settingsService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Site Ayarları başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // Edit Metatag 
        [Route("/admin/metatag/edit/{id?}")]
        public IActionResult Edit(int metatagId)
        {
            return View(_settingsService.GetById(metatagId));
        }
        [HttpPost, Route("/admin/metatag/edit/{id?}")]
        public async Task<IActionResult> Edit(Settings entity, IFormFile file)
        {
            var model = _settingsService.GetById(entity.SettingsId);

            if (file != null && file.ContentType.Contains("image"))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.SiteIcon = file.FileName;
            }
            else
            {
                entity.SiteIcon = model.SiteIcon;
            }
            if (ModelState.IsValid)
            {
                _settingsService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Site Ayarları başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        //Delete Metatag
        [Route("/admin/metatag/delete/{id?}")]
        public IActionResult Delete(int metatagId)
        {
            return View(_settingsService.GetById(metatagId));
        }
        [HttpPost, ActionName("Delete"), Route("/admin/metatag/delete/{id?}")]
        public IActionResult ConfirmedDelete(int metatagId)
        {
            var entity = _settingsService.GetById(metatagId);
            if (entity != null)
            {
                _settingsService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Site Ayarları başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }
    }
}