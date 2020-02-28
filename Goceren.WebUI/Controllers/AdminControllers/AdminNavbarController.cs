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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace Goceren.WebUI.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminNavbarController : Controller
    {
        private readonly INavbarService _navbarService;
        private readonly IMenuService _menuService;
        private readonly IMenuTypeService _menutypeService;
        private readonly ISocialService _socialService;
        public AdminNavbarController(INavbarService navbarService, IMenuService menuService, IMenuTypeService menutypeService, ISocialService socialService)
        {
            _navbarService = navbarService;
            _menuService = menuService;
            _menutypeService = menutypeService;
            _socialService = socialService;
        }


        // ------------------------------------------------------------------ NAVBAR ---------------------------------------------------------------------------

        // List of Navbar
        [Route("/admin/navbar")]
        public IActionResult Index()
        {
            var model = _navbarService.GetAll();
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
        // Create Navbar
        [Route("/admin/navbar/create")]
        public IActionResult Create()
        {
            return View(new Navbar());
        }
        [HttpPost, Route("/admin/navbar/create")]
        public async Task<IActionResult> Create(Navbar entity, IFormFile file)
        {
            if (file != null && file.ContentType.Contains("image"))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.NavbarImage = file.FileName;
            }
            if (ModelState.IsValid)
            {
                _navbarService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Navbar ayarı başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // Edit Navbar
        [Route("/admin/navbar/edit/{id?}")]
        public IActionResult Edit(int navbarId)
        {
            return View(_navbarService.GetById(navbarId));
        }
        [HttpPost, Route("/admin/navbar/edit/{id?}")]
        public async Task<IActionResult> Edit(Navbar entity, IFormFile file)
        {
            var model = _navbarService.GetById(entity.NavbarId);

            if (file != null && file.ContentType.Contains("image"))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.NavbarImage = file.FileName;

            }
            else
            {
                entity.NavbarImage = _navbarService.GetById(model.NavbarId).NavbarImage;
            }
            if (ModelState.IsValid)
            {
                _navbarService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Navbar ayarı başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // Delete Navbar
        [Route("/admin/navbar/delete/{id?}")]
        public IActionResult Delete(int navbarId)
        {
            return View(_navbarService.GetById(navbarId));
        }
        [HttpPost, ActionName("Delete"), Route("/admin/navbar/delete/{id?}")]
        public IActionResult ConfirmedDelete(int navbarId)
        {
            var entity = _navbarService.GetById(navbarId);
            if (entity != null)
            {
                _navbarService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Navbar ayarı başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }


        // ------------------------------------------------------------------ MENU ---------------------------------------------------------------------------


        // List of Menus
        [Route("/admin/menu")]
        public IActionResult Menues()
        {
            var model = _menuService.GetAllWithMenuType();
            ViewBag.items = model.Where(i => i.isApproved == true).Count();
            ViewBag.menutypes = _menutypeService.GetAll();
            if (ViewBag.items != 0)
            {
                ViewBag.alert = false;
            }
            else
            {
                ViewBag.alert = true;
            }
            return View(model);
        }

        // Create Menu
        [Route("/admin/menu/create")]
        public IActionResult AddMenu()
        {
            ViewBag.menutypes = new SelectList(_menutypeService.GetAll(), "MenuTypeId", "MenuTypeName");
            return View(new Menu());
        }
        [HttpPost, Route("/admin/menu/create")]
        public IActionResult AddMenu(Menu entity)
        {
            ViewBag.menutypes = new SelectList(_menutypeService.GetAll(), "MenuTypeId", "MenuTypeName");
            if (ModelState.IsValid)
            {
                _menuService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Menü ayarı başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Menues");
            }
            return View(entity);
        }

        // Edit Menu
        [Route("/admin/menu/edit/{id?}")]
        public IActionResult EditMenu(int menuId)
        {
            ViewBag.menutypes = new SelectList(_menutypeService.GetAll(), "MenuTypeId", "MenuTypeName");
            return View(_menuService.GetById(menuId));
        }
        [HttpPost, Route("/admin/menu/edit/{id?}")]
        public IActionResult EditMenu(Menu entity)
        {
            ViewBag.menutypes = new SelectList(_menutypeService.GetAll(), "MenuTypeId", "MenuTypeName");
            if (ModelState.IsValid)
            {
                _menuService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Menü ayarı başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Menues");
            }
            return View(entity);
        }

        // Delete Menu
        [Route("/admin/menu/delete/{id?}")]
        public IActionResult DeleteMenu(int menuId)
        {
            return View(_menuService.GetById(menuId));
        }
        [HttpPost, ActionName("DeleteMenu"), Route("/admin/menu/delete/{id?}")]
        public IActionResult ConfirmedDeleteMenu(int menuId)
        {
            var entity = _menuService.GetById(menuId);
            if (entity != null)
            {
                _menuService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Menü ayarı başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Menues");
        }


        // ------------------------------------------------------------------ MENU TYPE ---------------------------------------------------------------------------


        // List of Menu Type
        [Route("/admin/menutype")]
        public IActionResult MenuTypes()
        {
            var model = _menutypeService.GetAllWithObjects();
            ViewBag.items = model.Count();
            if (ViewBag.items != 0)
            {
                ViewBag.alert = false;
            }
            else
            {
                ViewBag.alert = true;
            }
            return View(model);
        }

        // Create MenuType
        [Route("/admin/menutype/create")]
        public IActionResult AddMenuType()
        {
            return View(new MenuType());
        }
        [HttpPost, Route("/admin/menutype/create")]
        public IActionResult AddMenuType(MenuType entity)
        {
            if (ModelState.IsValid)
            {
                _menutypeService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Menü Tipi başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("MenuTypes");
            }
            return View(entity);
        }

        // Edit MenuType
        [Route("/admin/menutype/edit/{id?}")]
        public IActionResult EditMenuType(int menutypeId)
        {
            return View(_menutypeService.GetByIdWithObjects(menutypeId));
        }
        [HttpPost, Route("/admin/menutype/edit/{id?}")]
        public IActionResult EditMenuType(MenuType entity)
        {

            if (ModelState.IsValid)
            {
                _menutypeService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Menü Tipi başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("MenuTypes");
            }
            entity.Menus = _menutypeService.GetByIdWithObjects(entity.MenuTypeId).Menus;
            return View(entity);
        }

        // Delete Menu Type
        [Route("/admin/menutype/delete/{id?}")]
        public IActionResult DeleteMenuType(int menutypeId)
        {
            return View(_menutypeService.GetById(menutypeId));
        }
        [HttpPost, ActionName("DeleteMenuType"), Route("/admin/menutype/delete/{id?}")]
        public IActionResult ConfirmedDeleteMenuType(int menutypeId)
        {
            var entity = _menutypeService.GetByIdWithObjects(menutypeId);
            if (entity != null)
            {
                if (entity.Menus != null)
                {
                    foreach (var item in entity.Menus)
                    {
                        var model = new Menu()
                        {
                            MenuId = item.MenuId,
                            isApproved = item.isApproved,
                            MenuLink = item.MenuLink,
                            MenuName = item.MenuName,
                            MenuTypeId = null
                        };
                        _menuService.Update(model);
                    }
                }
                _menutypeService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Menü Tipi başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("MenuTypes");
        }

        // Delete Menu Menutype Connection
        [Route("/admin/menu/menutype/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnections(int menutypeId, int menuId)
        {
            ViewBag.menutype = _menutypeService.GetById(menutypeId);
            return View(_menuService.GetById(menuId));
        }
        [HttpPost, ActionName("DeleteConnections"), Route("/admin/menu/menutype/connection/delete/{id?}/{idextra?}")]
        public IActionResult ConfirmedDeleteConnections(int menutypeId, int menuId)
        {
            ViewBag.menutype = _menutypeService.GetById(menutypeId);
            var model = _menuService.GetById(menuId);
            if (model != null)
            {
                var entity = new Menu()
                {
                    MenuId = model.MenuId,
                    isApproved = model.isApproved,
                    MenuLink = model.MenuLink,
                    MenuName = model.MenuName,
                    MenuTypeId = null
                };
                _menuService.Update(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Menü ile Menü Tipi bağlantısı başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("EditMenuType", new { menutypeId = menutypeId });
        }


        // ------------------------------------------------------------------ NAVBAR ---------------------------------------------------------------------------

        // Social Links List 
        [Route("/admin/social")]
        public IActionResult Social()
        {
            var model = _socialService.GetAll();
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

        // Create Social Link
        [Route("/admin/social/create")]
        public IActionResult AddSocial()
        {
            return View(new Social());
        }
        [HttpPost, Route("/admin/social/create")]
        public IActionResult AddSocial(Social entity)
        {
            if (ModelState.IsValid)
            {
                _socialService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Sosyal Medya Ayarı başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Social");
            }
            return View(entity);
        }

        // Edit Social Link
        [Route("/admin/social/edit/{id?}")]
        public IActionResult EditSocial(int socialId)
        {
            return View(_socialService.GetById(socialId));
        }
        [HttpPost, Route("/admin/social/edit/{id?}")]
        public IActionResult EditSocial(Social entity)
        {
            if (ModelState.IsValid)
            {
                _socialService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Sosyal Medya Ayarı başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Social");
            }
            return View(entity);
        }

        // Delete Social Link
        [Route("/admin/social/delete/{id?}")]
        public IActionResult DeleteSocial(int socialId)
        {
            return View(_socialService.GetById(socialId));
        }
        [HttpPost, ActionName("DeleteSocial"), Route("/admin/social/delete/{id?}")]
        public IActionResult ConfirmedDeleteSocial(int socialId)
        {
            var entity = _socialService.GetById(socialId);
            if (entity != null)
            {
                _socialService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Sosyal Medya Ayarı başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Social");
        }
    }
}