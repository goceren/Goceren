using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goceren.WebUI.Extensions;
using Goceren.WebUI.Identity;
using Goceren.WebUI.Models;
using Goceren.WebUI.Models.AdminModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Goceren.WebUI.Controllers.AdminControllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IEmailSender _emailsender;
        public AccountController(SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager, IEmailSender emailsender)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _emailsender = emailsender;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [Route("/account/register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    return Redirect("/admin");
                }
                if (User.IsInRole("user"))
                {
                    return Redirect("/user");
                }
            }
            return View(new RegisterModel());
        }
        [HttpPost, Route("/account/register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmMail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
                await _emailsender.SendEmailAsync(model.Email, "Emailinizi onaylayınız.", $"Lütfen hesabınızı onaylamak için linke <a href='https://goceren.com{callbackUrl}'>tıklayınız.</a> ");

                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Eposta Adresinize gelen Emaili kontrol ediniz ve emailde bulunan link ile hesabınızı onaylayınız.",
                    Css = "warning"
                });
                return RedirectToAction("login", "account");
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu lütfen tekrar deneyiniz.");
            return View(model);
        }

        [Route("/account/login")]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    return Redirect("/admin");
                }
                if (User.IsInRole("user"))
                {
                    return Redirect("/user");
                }
            }
            return View(new LoginModel()
            {
                returnUrl = returnUrl
            });
        }
        [HttpPost, Route("/account/login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            bool adminRole = await _userManager.IsInRoleAsync(user, "admin");
            bool userRole = await _userManager.IsInRoleAsync(user, "user");
            if (user == null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamış.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen Email adresinizi onaylayınız.");
                return View(model);
            }

            var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, true);
            if (result.Succeeded)
            {
                if (adminRole)
                {
                    return Redirect(model.returnUrl ?? "~/admin");
                }
                if (userRole)
                {
                    return Redirect(model.returnUrl ?? "~/user");
                }
            }
            ModelState.AddModelError("", "Email yada şifre yanlış");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            TempData.Put("message", new ResultMessage()
            {
                Title = "Oturum Kapatıldı",
                Message = "Hesabınızdan güvenli bir şekilde çıkış yapıldı.",
                Css = "warning"
            });
            return RedirectToAction("login", "account");
        }

        public async Task<IActionResult> ConfirmMail(string userId, string token)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    return Redirect("/admin");
                }
                if (User.IsInRole("user"))
                {
                    return Redirect("/user");
                }
            }
            if (userId == null || token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Hesap onayı için bilgileriniz yanlış",
                    Css = "danger"
                });
                return RedirectToAction("Login");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = "Hesabınız başarıyla onaylanmıştır.",
                        Css = "success"
                    });
                    return RedirectToAction("Login");
                }               
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = "Hesabınız onaylanamadı..",
                Css = "danger"
            });
            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Lütfen Email Adresi giriniz.",
                    Css = "danger"
                });
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Girdiğiniz Email Adresi ile eşleşen bir hesap bulunamadı.",
                    Css = "danger"
                });
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code
            });

            await _emailsender.SendEmailAsync(email, "Şifre Sıfırlama", $"Lütfen şifrenizi sıfırlamak için buraya <a href='https://goceren.com{callbackUrl}'>tıklayınız.</a> ");


            TempData.Put("message", new ResultMessage()
            {
                Title = "Şifremi Unuttum",
                Message = "Parola yenilemek için email adresinize posta gönderildi.",
                Css = "warning"
            });
            return RedirectToAction("login", "account");
        }

       [Route("/account/resetpassword")]
        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifre Sıfırla",
                    Message = "Hatalı Token",
                    Css = "danger"
                });

                return RedirectToAction("Login");
            }
            var model = new ForgotResetPasswordModel { Token = token };
            return View(model);
        }
        [HttpPost, Route("/account/resetpassword")]
        public async Task<IActionResult> ResetPasswordAsync(ForgotResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifre Sıfırla",
                    Message = "Girdiğiniz email adresi kayıtlı değil.",
                    Css = "danger"
                });
                return RedirectToAction("Login");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Şifreniz başarı ile değiştirildi.",
                    Css = "success"
                });
                return RedirectToAction("Login", "Account");
            }
            TempData.Put("message", new ResultMessage()
            {
                Title = "Şifre Sıfırla",
                Message = "Geçersiz Yönlendirme. Emailinize gelen linki takip ediniz.",
                Css = "danger"
            });
            return View(model);
        }
        [Route("/account/accessdenied")]
        public IActionResult AccessDenied()
        {
            TempData.Put("message", new ResultMessage()
            {
                Title = "İzinsiz Erişim",
                Message = "Bu sayfaya giriş izniniz yok.",
                Css = "danger"
            });
            return View();
        }             
    }
}