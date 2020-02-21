using Goceren.Business.Abstract;
using Goceren.Entities;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.ViewComponents
{
    public class MetatagsViewComponent : ViewComponent
    {
        private ISettingsService _settingsService;
        public MetatagsViewComponent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IViewComponentResult Invoke()
        {
            Settings model = new Settings();
            try
            {
                model = _settingsService.GetAll().Where(i => i.isApproved == true).First();
                return View(model);

            }
            catch (Exception)
            {
                model = null;
                return View(model);
            }
                        
        }
    }
}
