using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.Entities;
using Goceren.WebUI.Extensions;
using Goceren.WebUI.Models;
using Goceren.WebUI.Models.AdminModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goceren.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IHomepageService _homepageService;
        private readonly ISubtitleService _subtitleService;
        private readonly IHomeSubtitleService _homesubtitleService;
        private readonly IWhatIDoService _whatIDoService;
        private readonly ITweetsService _tweetsService;
        public AdminController(IHomepageService homepageService, ISubtitleService subtitleService, IWhatIDoService whatIDoService, ITweetsService tweetsService, IHomeSubtitleService homesubtitleService)
        {
            _homepageService = homepageService;
            _subtitleService = subtitleService;
            _whatIDoService = whatIDoService;
            _tweetsService = tweetsService;
            _homesubtitleService = homesubtitleService;
        }
        // ----------------------------------------------------   HOMEPAGE  -----------------------------------------------------

        // Homepage List
        [Route("/admin")]
        public IActionResult Index()
        {
            var model = _homepageService.GetAll();
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

        // Create Homepage
        [Route("/admin/homepage/create")]
        public IActionResult AddHomepage()
        {
            return View(new Homepage());
        }
        [HttpPost, Route("/admin/homepage/create")]
        public async Task<IActionResult> AddHomepageAsync(Homepage entity, IFormFile file, IFormFile fileCV)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    entity.AboutImage = file.FileName;
                }
                if (fileCV != null)
                {
                    var pathCV = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CV", fileCV.FileName);
                    using (var streamCV = new FileStream(pathCV, FileMode.Create))
                    {
                        await fileCV.CopyToAsync(streamCV);
                    }
                    entity.CVLink = fileCV.FileName;
                }
                _homepageService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Anasayfa başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        //Edit Homepage
        [Route("/admin/homepage/edit/{id?}")]
        public IActionResult EditHomepage(int pageId)
        {
            var entity = _homepageService.GetByIdWithSubtitles(pageId);
            ViewBag.subtitles = _subtitleService.GetAll();
            return View(entity);
        }
        [HttpPost, Route("/admin/homepage/edit/{id?}")]
        public async Task<IActionResult> EditHomepage(Homepage entity, IFormFile file, IFormFile fileCV, int[] subtitleId)
        {
            var model = _homepageService.GetByIdWithSubtitles(entity.HomepageId);
            ViewBag.subtitles = _subtitleService.GetAll();
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Site\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.AboutImage = file.FileName;
            }
            else
            {
                entity.AboutImage = _homepageService.GetById(model.HomepageId).AboutImage;
            }
            if (fileCV != null)
            {
                var pathCV = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CV", fileCV.FileName);
                using (var streamCV = new FileStream(pathCV, FileMode.Create))
                {
                    await fileCV.CopyToAsync(streamCV);
                }
                entity.CVLink = fileCV.FileName;
            }
            else
            {
                entity.CVLink = _homepageService.GetById(model.HomepageId).CVLink;
            }
            if (ModelState.IsValid)
            {                      
                _homepageService.Update(entity, subtitleId);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Anasayfa başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            ViewBag.selected = subtitleId;
            return View(entity);
        }

        //Delete Homepage
        [Route("/admin/homepage/delete/{id?}")]
        public IActionResult DeleteHomepage(int pageId)
        {
            return View(_homepageService.GetById(pageId));
        }

        [HttpPost, ActionName("DeleteHomepage"), Route("/admin/homepage/delete/{id?}")]
        public IActionResult DeleteConfirmed(int pageId)
        {
            var entity = _homepageService.GetById(pageId);
            var homesubtitles = _homesubtitleService.GetAll().Where(i => i.HomepageId == pageId).ToList();
            if (entity != null)
            {
                if (homesubtitles != null)
                {
                    foreach (var item in homesubtitles)
                    {
                        _homesubtitleService.Delete(item);
                    }
                }
                _homepageService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Anasayfa başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }

        // ----------------------------------------------------   SUBTITLE  -----------------------------------------------------

        // List of Subtitles
        [Route("/admin/subtitle")]
        public IActionResult Subtitle()
        {
            var subtitle = _subtitleService.GetAll();
            List<SubtitleAdminModels> model = new List<SubtitleAdminModels>();
            if (subtitle != null)
            {
                foreach (var item in subtitle)
                {
                    SubtitleAdminModels box = new SubtitleAdminModels
                    {
                        SubtitleId = _subtitleService.GetByIdWithHomepage(item.SubtitleId).SubtitleId,
                        SubtitleName = _subtitleService.GetByIdWithHomepage(item.SubtitleId).SubtitleName,
                        isApproved = _subtitleService.GetByIdWithHomepage(item.SubtitleId).isApproved,
                        Homepage = _subtitleService.GetByIdWithHomepage(item.SubtitleId).HomeSubtitle.Select(i => i.Homepage).ToList()
                    };
                    model.Add(box);
                }
            }
            return View(model);
        }

        // Create Subtitle
        [Route("/admin/subtitle/create")]
        public IActionResult AddSubtitle()
        {
            return View(new Subtitle());
        }
        [HttpPost, Route("/admin/subtitle/create")]
        public IActionResult AddSubtitle(Subtitle entity)
        {
            ViewBag.homepages = _homepageService.GetAll();
            if (ModelState.IsValid)
            {
                _subtitleService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Alt Başlık başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Subtitle");
            }
            return View(entity);      
        }

        // Edit Subtitle
        [Route("/admin/subtitle/edit/{id?}")]
        public IActionResult EditSubtitle(int subtitleId)
        {
            var entity = _subtitleService.GetByIdWithHomepage(subtitleId);
            var model = new SubtitleAdminModels();
            if (entity != null && model != null)
            {
                model.SubtitleName = entity.SubtitleName;
                model.isApproved = entity.isApproved;
                model.SubtitleId = entity.SubtitleId;
                model.Homepage = entity.HomeSubtitle.Select(i => i.Homepage).ToList();
            }
            return View(model);
        }
        [HttpPost, Route("/admin/subtitle/edit/{id?}")]
        public IActionResult EditSubtitle(SubtitleAdminModels model)
        {
            if (ModelState.IsValid)
            {
                var entity = _subtitleService.GetById(model.SubtitleId);
                entity.SubtitleName = model.SubtitleName;
                entity.isApproved = model.isApproved;
                _subtitleService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Alt Başlık başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Subtitle");
            }
            return View(model);
        }

        // Delete HomeSubtitle Connection
        [Route("/admin/home/subtitle/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteHomeSubtitle(int homeId, int subtitleId)
        {
            var entity = _subtitleService.GetByIdWithHomepage(subtitleId);
            var model = new SubtitleAdminModels();
            if (entity != null && model != null)
            {
                model.SubtitleName = entity.SubtitleName;
                model.isApproved = entity.isApproved;
                model.SubtitleId = entity.SubtitleId;
                model.Homepage = entity.HomeSubtitle.Select(i => i.Homepage).Where(i => i.HomepageId == homeId).ToList();
            }

            return View(model);
        }
        [HttpPost, ActionName("DeleteHomeSubtitle"), Route("/admin/home/subtitle/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteHomeSubtitleConfirmed(int homeId, int subtitleId)
        {
            var entity = _homesubtitleService.GetById(homeId, subtitleId);
            if (entity != null)
            {
                _homesubtitleService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Bağlantı başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("EditSubtitle", new { subtitleId = subtitleId });
        }

        // Delete Subtitle
        [Route("/admin/subtitle/delete/{id?}")]
        public IActionResult DeleteSubtitle(int subtitleId)
        {
            var entity = _subtitleService.GetByIdWithHomepage(subtitleId);
            var model = new SubtitleAdminModels();
            model.SubtitleName = entity.SubtitleName;
            model.isApproved = entity.isApproved;
            model.SubtitleId = entity.SubtitleId;
            model.Homepage = entity.HomeSubtitle.Select(i => i.Homepage).ToList();
            return View(model);
        }
        [HttpPost, ActionName("DeleteSubtitle"), Route("/admin/subtitle/delete/{id?}")]
        public IActionResult DeleteSubtitleConfirmed(int subtitleId)
        {
            var entity = _subtitleService.GetById(subtitleId);
            var homesubtitles = _homesubtitleService.GetAll().Where(i => i.SubtitleId == subtitleId).ToList();
            if (entity != null)
            {
                if (homesubtitles != null)
                {
                    foreach (var item in homesubtitles)
                    {
                        _homesubtitleService.Delete(item);
                    }
                }
                _subtitleService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Alt Başlık başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Subtitle");
        }

        // ----------------------------------------------------   WHAT I DO  -----------------------------------------------------

        // List of What I Do
        [Route("/admin/whatido")]
        public IActionResult WhatIDo()
        {
            var model = _whatIDoService.GetAll();
            ViewBag.items = model.Where(i => i.isApproved == true).Count();
            if (ViewBag.items == 2)
            {
                ViewBag.alert = false;
            }
            else
            {
                ViewBag.alert = true;
            }
            return View(model);
        }

        // Create What I Do
        [Route("/admin/whatido/create")]
        public IActionResult AddWhatIDo()
        {
            return View(new WhatIDo());
        }
        [HttpPost, Route("/admin/whatido/create")]
        public IActionResult AddWhatIDo(WhatIDo entity)
        {
            if (ModelState.IsValid)
            {
                _whatIDoService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "What I Do başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("WhatIDo");

            }
            return View(entity);
        }

        // Edit What I Do
        [Route("/admin/whatido/edit/{id?}")]
        public IActionResult EditWhatIDo(int whatidoId)
        {
            return View(_whatIDoService.GetById(whatidoId));
        }
        [HttpPost, Route("/admin/whatido/edit/{id?}")]
        public IActionResult EditWhatIDo(WhatIDo entity)
        {
            if (ModelState.IsValid)
            {
                _whatIDoService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "What I Do başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("WhatIDo");
            }
            return View(entity);
        }

        // Delete What I Do
        [Route("/admin/whatido/delete/{id?}")]
        public IActionResult DeleteWhatIDo(int whatidoId)
        {
            return View(_whatIDoService.GetById(whatidoId));
        }
        [HttpPost, ActionName("DeleteWhatIDo"), Route("/admin/whatido/delete/{id?}")]
        public IActionResult ConfirmedDeleteWhatIDo(int whatidoId)
        {
            var entity = _whatIDoService.GetById(whatidoId);
            if (entity != null)
            {
                _whatIDoService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "What I Do başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("WhatIDo");
        }

        // ----------------------------------------------------   TWITTER  -----------------------------------------------------

        // List of Twitter Settings
        [Route("/admin/twitter")]
        public IActionResult Twitter()
        {
            var model = _tweetsService.GetAll();
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

        // Create Twitter Settings
        [Route("/admin/twitter/create")]
        public IActionResult AddTwitter()
        {
            return View(new Tweets());
        }
        [HttpPost, Route("/admin/twitter/create")]
        public IActionResult AddTwitter(Tweets entity)
        {
            if (ModelState.IsValid)
            {
                _tweetsService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Twitter ayarı başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Twitter");
            }
            return View(entity);
        }

        // Edit Twitter Settings 
        [Route("/admin/twitter/edit/{id?}")]
        public IActionResult EditTwitter(int twitterId)
        {
            return View(_tweetsService.GetById(twitterId));
        }
        [HttpPost, Route("/admin/twitter/edit/{id?}")]
        public IActionResult EditTwitter(Tweets entity)
        {
            if (ModelState.IsValid)
            {
                _tweetsService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Twitter ayarı başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Twitter");
            }
            return View(entity);
        }

        // Delete Twitter Settings 
        [Route("/admin/twitter/delete/{id?}")]
        public IActionResult DeleteTwitter(int twitterId)
        {
            return View(_tweetsService.GetById(twitterId));
        }
        [HttpPost, ActionName("DeleteTwitter"), Route("/admin/twitter/delete/{id?}")]
        public IActionResult ConfirmedDeleteTwitter(int twitterId)
        {
            var entity = _tweetsService.GetById(twitterId);
            if (entity != null)
            {
                _tweetsService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Twitter ayarı başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Twitter");
        }
    }
}