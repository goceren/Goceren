using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.WebUI.Extensions;
using Goceren.WebUI.Identity;
using Goceren.WebUI.Models;
using Goceren.WebUI.Models.AdminModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Goceren.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminManageUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBlogService _blogService;
        public AdminManageUserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IBlogService blogService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _blogService = blogService;
        }

        [Route("/admin/users")]
        public IActionResult Index()
        {
            var users = new List<UserModel>();
            foreach (var item in _userManager.Users)
            {
                var user = new UserModel()
                {
                    Confirmed = item.EmailConfirmed,
                    Email = item.Email,
                    ID = item.Id,
                    Phone = item.PhoneNumber,
                    UserName = item.UserName,
                    RoleId = _userManager.GetRolesAsync(item).Result.FirstOrDefault()
                };
                users.Add(user);
            }
            return View(users);
        }

        [Route("/admin/user/delete/{name?}")]
        public async Task<IActionResult> DeleteAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return View(user);
        }

        [Route("/admin/user/edit/{username?}")]
        public async Task<IActionResult> EditUserAsync(string userName)
        {
            var roles = _roleManager.Roles;
            ViewBag.roles = new SelectList(roles, "Name", "Name");
            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);
            var model = new UserModel()
            {
                ID = user.Id,
                Confirmed = user.EmailConfirmed,
                Email = user.Email,
                Phone = user.PhoneNumber,
                UserName = user.UserName,
                RoleId = userRoles.FirstOrDefault()
            };
            return View(model);
        }

        [HttpPost, Route("/admin/user/edit/{username?}")]
        public async Task<IActionResult> EditUserAsync(UserModel model)
        {
            var roles = _roleManager.Roles;
            ViewBag.roles = new SelectList(roles, "Name", "Name");
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.ID);
                if (user == null)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Kullanıcı Güncelle",
                        Message = "Kullanıcı Bulunamadı",
                        Css = "danger"
                    });
                    return RedirectToAction("Index");
                }
                var userVYG = await _userManager.FindByEmailAsync("vygoceren@gmail.com");
                if (User.Identity.Name != userVYG.UserName)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Kullanıcı Güncelle",
                        Message = "Kullanıcı Güncelleme Yetkiniz Yok",
                        Css = "danger"
                    });
                    return RedirectToAction("Index");
                }
                user.Email = model.Email;
                user.EmailConfirmed = model.Confirmed;
                user.PhoneNumber = model.Phone;
                user.UserName = model.UserName;
                if (!(await _userManager.IsInRoleAsync(user, model.RoleId)))
                {

                    var userrole = await _userManager.GetRolesAsync(user);
                    RoleModel models = new RoleModel()
                    {
                        RoleName = userrole.First()
                    };

                    if (await _userManager.IsInRoleAsync(user, models.RoleName))
                    {
                        await _userManager.RemoveFromRoleAsync(user, models.RoleName);
                    }
                    await _userManager.AddToRoleAsync(user, model.RoleId);
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Kullanıcı Güncelle",
                        Message = "Kullanıcı Güncelleme Başarılı",
                        Css = "success"
                    });

                    return RedirectToAction("Index");
                }
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Kullanıcı Güncelle",
                Message = "Kullanıcı Güncelleme Başarısız",
                Css = "danger"
            });
            return View(model);
        }

        [HttpPost, Route("/admin/user/delete/{name?}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Kullanıcı Sil",
                    Message = "Kullanıcı Bulunamadı",
                    Css = "danger"
                });
                return RedirectToAction("Index");
            }
            var userVYG = await _userManager.FindByEmailAsync("vygoceren@gmail.com");
            bool role = await _userManager.IsInRoleAsync(user, "admin");
            if (role || User.Identity.Name == userVYG.UserName)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Kullanıcı Sil",
                        Message = "Kullanıcı Başarıyla Silindi",
                        Css = "success"
                    });
                    var blogs = _blogService.GetAll().Where(i => i.UserName == user.UserName);
                    if (blogs != null)
                    {
                        foreach (var item in blogs)
                        {
                            item.BlogConfirm = false;
                            _blogService.Update(item);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Kullanıcı Sil",
                Message = "Admin Silme Yetkiniz Yok!",
                Css = "danger"
            });
            return RedirectToAction("Index");
        }

        [Route("/admin/roles")]
        public IActionResult Role()
        {
            var roles = new List<GetRoleModel>();
            foreach (var item in _roleManager.Roles)
            {
                var role = new GetRoleModel()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                roles.Add(role);
            }
            return View(roles);
        }

        [Route("/admin/role/create")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost, Route("/admin/role/create")]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Rol Ekleme",
                        Message = "Rol Başarıyla Eklendi!",
                        Css = "success"
                    });
                    return RedirectToAction("Role");
                }
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Rol Ekleme",
                    Message = "Rol Ekleme Başarısız!",
                    Css = "danger"
                });
                return View(model);
            }
            return View(model);
        }

        [Route("/admin/role/edit/{id?}")]
        public IActionResult EditRole(string roleId)
        {
            var roles = new List<GetRoleModel>();
            foreach (var item in _roleManager.Roles)
            {
                var role = new GetRoleModel()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                roles.Add(role);
            }
            return View(roles.Where(i => i.Id == roleId).FirstOrDefault());
        }

        [HttpPost, Route("/admin/role/edit/{id?}")]
        public async Task<IActionResult> EditRoleAsync(GetRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = await _roleManager.FindByIdAsync(model.Id);
                if (identityRole.Name == "admin" || identityRole.Name == "user")
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Rol Güncelleme",
                        Message = "Bu Rolü Güncelleme Yetkiniz Yok!",
                        Css = "danger"
                    });
                    return RedirectToAction("Role");
                }
                identityRole.Name = model.Name;
                IdentityResult result = await _roleManager.UpdateAsync(identityRole);
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Rol Güncelleme",
                        Message = "Rol Başarıyla Güncellendi!",
                        Css = "success"
                    });
                    return RedirectToAction("Role");
                }
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Rol Güncelleme",
                    Message = "Rol Güncelleme Başarısız!",
                    Css = "danger"
                });
                return View(model);
            }
            return View(model);
        }

        [Route("/admin/role/delete/{id?}")]
        public IActionResult DeleteRole(string roleId)
        {
            var roles = new List<GetRoleModel>();
            foreach (var item in _roleManager.Roles)
            {
                var role = new GetRoleModel()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                roles.Add(role);
            }
            return View(roles.Where(i => i.Id == roleId).FirstOrDefault());
        }

        [HttpPost, ActionName("DeleteRole"), Route("/admin/role/delete/{id?}")]
        public async Task<IActionResult> DeleteRoleConfirmAsync(string roleId)
        {
            var roles = new List<GetRoleModel>();
            if (!string.IsNullOrEmpty(roleId))
            {
                IdentityRole identityRole = await _roleManager.FindByIdAsync(roleId);
                if (identityRole == null)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Rol Silme",
                        Message = "Rol Silme Başarısız!",
                        Css = "danger"
                    });
                }
                if (identityRole.Name == "admin" || identityRole.Name == "user")
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Rol Silme",
                        Message = "Bu rolü silme yetkiniz yok!",
                        Css = "danger"
                    });
                    return RedirectToAction("Role");
                }
                var result = await _roleManager.DeleteAsync(identityRole);
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Rol Silme",
                        Message = "Rol Başarıyla silindi!",
                        Css = "success"
                    });
                    return RedirectToAction("Role");
                }
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Rol Silme",
                    Message = "Rol Silme Başarısız!",
                    Css = "danger"
                });
                return RedirectToAction("Role");
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Rol Silme",
                    Message = "Rol Silme Başarısız!",
                    Css = "danger"
                });
                return RedirectToAction("Role");
            }
        }
    }
}