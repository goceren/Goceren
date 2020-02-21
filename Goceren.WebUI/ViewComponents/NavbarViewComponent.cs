using Goceren.Business.Abstract;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.ViewComponents
{
    public class NavbarViewComponent: ViewComponent
    {
        private readonly INavbarService _navbarService;
        private readonly IMenuService _menuService;
        private readonly ISocialService _socialService;

        public NavbarViewComponent(INavbarService navbarService, ISocialService socialService, IMenuService menuService)
        {
            _navbarService = navbarService;
            _socialService = socialService;
            _menuService = menuService;
        }
        public IViewComponentResult Invoke()
        {
            NavbarModels model = new NavbarModels();
            try
            {
                model.Navbar = _navbarService.GetAll().Where(i => i.isApproved == true).First();
            }
            catch (Exception)
            {

                model.Navbar = null;
            }
            try
            {
                model.Social = _socialService.GetAll().Where(i => i.isApproved == true).First();
                
            }
            catch (Exception)
            {

                model.Social = null;
                
            }
            try
            {
                model.Menu = _menuService.GetAllWithMenuType().Where(i => i.isApproved).ToList();
            }
            catch (Exception)
            {

                model.Menu = null;
            }

            return View(model);
        }
    }
}
