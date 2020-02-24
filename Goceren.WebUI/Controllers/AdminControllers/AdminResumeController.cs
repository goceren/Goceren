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
    public class AdminResumeController : Controller
    {
        private readonly IResumepageService _resumepageService;
        private readonly IHomepageService _homepageService;
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        private readonly ISkillsService _skillsService;
        public AdminResumeController(IResumepageService resumepageService, IHomepageService homepageService, IEducationService educationService, ISkillsService skillsService, IExperienceService experienceService)
        {
            _resumepageService = resumepageService;
            _homepageService = homepageService;
            _educationService = educationService;
            _experienceService = experienceService;
            _skillsService = skillsService;
        }

        // Resumepage List 
        [Route("/admin/resume")]
        public IActionResult Index()
        {
            var model = _resumepageService.GetAll();
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

        // Create Resumepage 
        [Route("/admin/resume/create")]
        public IActionResult Create()
        {
            return View(new Resumepage());
        }
        [HttpPost, Route("/admin/resume/create")]
        public IActionResult Create(Resumepage entity)
        {
            var cvLink = _homepageService.GetAll().Where(i => i.isApproved == true).First().CVLink;
            entity.CVLink = cvLink;
            if (ModelState.IsValid)
            {
                _resumepageService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Hakkımda sayfası başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            return View(entity);

        }

        // Edit Resumepage 
        [Route("/admin/resume/edit/{id?}")]
        public IActionResult Edit(int resumepageId)
        {
            return View(_resumepageService.GetByIdWithObjects(resumepageId));
        }
        [HttpPost, Route("/admin/resume/edit/{id?}")]
        public IActionResult Edit(Resumepage entity)
        {
            var cvLink = _homepageService.GetAll().Where(i => i.isApproved == true).First().CVLink;
            entity.CVLink = cvLink;
            if (ModelState.IsValid)
            {
                _resumepageService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Hakkımda sayfası başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Index");
            }
            var obj = _resumepageService.GetByIdWithObjects(entity.ResumepageId);
            entity.Educations = obj.Educations;
            entity.Experiences = obj.Experiences;
            entity.Skills = obj.Skills;
            return View(entity);
        }

        // Delete Resumepage
        [Route("/admin/resume/delete/{id?}")]
        public IActionResult Delete(int resumepageId)
        {
            return View(_resumepageService.GetByIdWithObjects(resumepageId));
        }
        [HttpPost, ActionName("Delete"), Route("/admin/resume/delete/{id?}")]
        public IActionResult ConfirmedDelete(int resumepageId)
        {
            var entity = _resumepageService.GetByIdWithObjects(resumepageId);
            if (entity != null)
            {
                if (entity.Skills.Count != 0)
                {
                    foreach (var item in entity.Skills)
                    {
                        var model = new Skills()
                        {
                            isApproved = item.isApproved,
                            ResumepageId = null,
                            SkillPercent = item.SkillPercent,
                            SkillsId = item.SkillsId,
                            SkillTitle = item.SkillTitle
                        };
                        _skillsService.Update(model);
                    }
                }
                if (entity.Educations.Count != 0)
                {
                    foreach (var item in entity.Educations)
                    {
                        var model = new Education()
                        {
                            isApproved = item.isApproved,
                            ResumepageId = null,
                            Date = item.Date,
                            Description = item.Description,
                            EducationId = item.EducationId,
                            EducationType = item.EducationType,
                            Title = item.Title,
                        };
                        _educationService.Update(model);
                    }
                }
                if (entity.Experiences.Count != 0)
                {
                    foreach (var item in entity.Experiences)
                    {
                        var model = new Experience()
                        {
                            isApproved = item.isApproved,
                            ResumepageId = null,
                            Date = item.Date,
                            Description = item.Description,
                            ExperienceId = item.ExperienceId,
                            CompanyName = item.CompanyName,
                            Title = item.Title,
                        };
                        _experienceService.Update(model);
                    }
                }
                _resumepageService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Hakkımda sayfası ve bağlantılar başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Index");
        }




        // -------------------------------------------------------------- EDUCATIONS ---------------------------------------------------------------

        // Educations
        [Route("/admin/education")]
        public IActionResult Educations()
        {
            var model = _educationService.GetAllWithResume();
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

        // Create Education
        [Route("/admin/education/create")]
        public IActionResult AddEducation()
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            return View(new Education());
        }
        [HttpPost, Route("/admin/education/create")]
        public IActionResult AddEducation(Education entity)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            if (ModelState.IsValid)
            {
                _educationService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Eğitim Bilgisi başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Educations");
            }
            return View(entity);
        }

        // Edit Education
        [Route("/admin/education/edit/{id?}")]
        public IActionResult EditEducation(int educationId)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            return View(_educationService.GetById(educationId));
        }
        [HttpPost, Route("/admin/education/edit/{id?}")]
        public IActionResult EditEducation(Education entity)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            if (ModelState.IsValid)
            {
                _educationService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Eğitim Bilgisi başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Educations");
            }
            return View(entity);         
        }

        // Delete Education
        [Route("/admin/education/delete/{id?}")]
        public IActionResult DeleteEducation(int educationId)
        {
            return View(_educationService.GetById(educationId));
        }
        [HttpPost, ActionName("DeleteEducation"), Route("/admin/education/delete/{id?}")]
        public IActionResult ConfirmedDeleteEducation(int educationId)
        {
            var entity = _educationService.GetById(educationId);
            if (entity != null)
            {
                _educationService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Eğitim Bilgisi başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Educations");
        }


        // -------------------------------------------------------------- EXPERIENCES ---------------------------------------------------------------


        // Experiences
        [Route("/admin/experience")]
        public IActionResult Experiences()
        {
            var model = _experienceService.GetAllWithResume();
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

        // Create Experience
        [Route("/admin/experience/create")]
        public IActionResult AddExperience()
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            return View(new Experience());
        }
        [HttpPost, Route("/admin/experience/create")]
        public IActionResult AddExperience(Experience entity)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            if (ModelState.IsValid)
            {
                _experienceService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Tecrübe Bilgisi başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Experiences");
            }
            return View(entity);
        }

        //Edit Experience
        [Route("/admin/experience/edit/{id?}")]
        public IActionResult EditExperience(int experienceId)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            return View(_experienceService.GetById(experienceId));
        }
        [HttpPost, Route("/admin/experience/edit/{id?}")]
        public IActionResult EditExperience(Experience entity)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            if (ModelState.IsValid)
            {
                _experienceService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Tecrübe Bilgisi başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Experiences");
            }
            return View(entity);
        }

        // Delete Experience
        [Route("/admin/experience/delete/{id?}")]
        public IActionResult DeleteExperience(int experienceId)
        {
            return View(_experienceService.GetById(experienceId));
        }
        [HttpPost, ActionName("DeleteExperience"), Route("/admin/experience/delete/{id?}")]
        public IActionResult ConfirmedDeleteExperience(int experienceId)
        {
            var entity = _experienceService.GetById(experienceId);
            if (entity != null)
            {
                _experienceService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Tecrübe Bilgisi başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Experiences");
        }


        // -------------------------------------------------------------- SKILLS ---------------------------------------------------------------

        // Skills
        [Route("/admin/skill")]
        public IActionResult Skills()
        {
            var model = _skillsService.GetAllWithResume();
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

        // Create Skill
        [Route("/admin/skill/create")]
        public IActionResult AddSkill()
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            return View(new Skills());
        }
        [HttpPost, Route("/admin/skill/create")]
        public IActionResult AddSkill(Skills entity)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            if (ModelState.IsValid)
            {
                _skillsService.Create(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Yetenek Bilgisi başarılı bir şekilde oluşturuldu.",
                    Css = "success"
                });
                return RedirectToAction("Skills");
            }
            return View(entity);
        }

        // Edit Skill
        [Route("/admin/skill/edit/{id?}")]
        public IActionResult EditSkill(int skillId)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            return View(_skillsService.GetById(skillId));
        }
        [HttpPost, Route("/admin/skill/edit/{id?}")]
        public IActionResult EditSkill(Skills entity)
        {
            ViewBag.resumepages = new SelectList(_resumepageService.GetAll(), "ResumepageId", "ResumepageTitle");
            if (ModelState.IsValid)
            {
                _skillsService.Update(entity);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Bildirim",
                    Message = "Yetenek Bilgisi başarılı bir şekilde güncellendi.",
                    Css = "success"
                });
                return RedirectToAction("Skills");
            }
            return View(entity);
        }

        // Delete Skill
        [Route("/admin/skill/delete/{id?}")]
        public IActionResult DeleteSkill(int skillId)
        {
            return View(_skillsService.GetById(skillId));
        }
        [HttpPost, ActionName("DeleteSkill"), Route("/admin/skill/delete/{id?}")]
        public IActionResult ConfirmedDeleteSkill(int skillId)
        {
            var entity = _skillsService.GetById(skillId);
            if (entity != null)
            {
                _skillsService.Delete(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Yetenek Bilgisi başarılı bir şekilde silindi.",
                Css = "success"
            });
            return RedirectToAction("Skills");
        }


        // -------------------------------------------------------------- DELETE CONNECTIONS  ---------------------------------------------------------------

        // Delete Skill Resumepage Connection
        [Route("/admin/resume/skill/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnectionSkill(int skillId, int resumepageId)
        {
            ViewBag.resumepage = _resumepageService.GetById(resumepageId);
            return View(_skillsService.GetById(skillId));
        }
        [HttpPost, ActionName("DeleteConnectionSkill"), Route("/admin/resume/skill/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnectionSkillsWithResume(int skillId, int resumepageId)
        {
            ViewBag.resume = _resumepageService.GetById(resumepageId);
            var model = _skillsService.GetById(skillId);
            if (model != null)
            {
                var entity = new Skills()
                {
                    isApproved = model.isApproved,
                    ResumepageId = null,
                    SkillPercent = model.SkillPercent,
                    SkillTitle = model.SkillTitle,
                    SkillsId = model.SkillsId
                };
                _skillsService.Update(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Yetenek Bilgisi ile Hakkımda sayfası bağlantısı başarılı bir şekilde kaldırıldı.",
                Css = "success"
            });
            return RedirectToAction("Edit", new { resumepageId = resumepageId });

            // Delete Education Resumepage Connection
        }
        [Route("/admin/resume/education/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnectionEducation(int educationId, int resumepageId)
        {
            ViewBag.resumepage = _resumepageService.GetById(resumepageId);
            return View(_educationService.GetById(educationId));
        }
        [HttpPost, ActionName("DeleteConnectionEducation"), Route("/admin/resume/education/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnectionEducationsWithResume(int educationId, int resumepageId)
        {
            ViewBag.resume = _resumepageService.GetById(resumepageId);
            var model = _educationService.GetById(educationId);
            if (model != null)
            {
                var entity = new Education()
                {
                    isApproved = model.isApproved,
                    ResumepageId = null,
                    Date = model.Date,
                    Description = model.Description,
                    EducationId = model.EducationId,
                    Title = model.Title,
                    EducationType = model.EducationType
                };
                _educationService.Update(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Eğitim Bilgisi ile Hakkımda sayfası bağlantısı başarılı bir şekilde kaldırıldı.",
                Css = "success"
            });
            return RedirectToAction("Edit", new { resumepageId = resumepageId });

        }


        // Delete Experience Resumepage Connection
        [Route("/admin/resume/experience/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnectionExperience(int experienceId, int resumepageId)
        {
            ViewBag.resumepage = _resumepageService.GetById(resumepageId);
            return View(_experienceService.GetById(experienceId));
        }
        [HttpPost, ActionName("DeleteConnectionExperience"), Route("/admin/resume/experience/connection/delete/{id?}/{idextra?}")]
        public IActionResult DeleteConnectionExperiencesWithResume(int experienceId, int resumepageId)
        {
            ViewBag.resume = _resumepageService.GetById(resumepageId);
            var model = _experienceService.GetById(experienceId);
            if (model != null)
            {
                var entity = new Experience()
                {
                    isApproved = model.isApproved,
                    ResumepageId = null,
                    Date = model.Date,
                    Description = model.Description,
                    ExperienceId = model.ExperienceId,
                    Title = model.Title,
                    CompanyName = model.CompanyName
                };
                _experienceService.Update(entity);
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Bildirim",
                Message = "Tecrübe Bilgisi ile Hakkımda sayfası bağlantısı başarılı bir şekilde kaldırıldı.",
                Css = "success"
            });
            return RedirectToAction("Edit", new { resumepageId = resumepageId });
        }

    }
}