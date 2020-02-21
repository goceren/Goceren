using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.Entities;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Goceren.WebUI.Controllers
{
    public class ResumeController : Controller
    {
        private IResumepageService _resumepageService;

        public ResumeController(IResumepageService resumepageService)
        {
            _resumepageService = resumepageService;
        }
        public IActionResult Index()
        {
            Resumepage model = new Resumepage();
            try
            {
                model = _resumepageService.GetAllWithObjects().Where(i => i.isApproved == true).First();
            }
            catch (Exception)
            {

                model = null;
            }
            return View(model);
        }
    }
}