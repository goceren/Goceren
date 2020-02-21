using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models.AdminModels
{
    public class ForgotResetPasswordModel
    {
        [Required(ErrorMessage = "Token Hatalı")]
        public string Token { get; set; }
        [Required(ErrorMessage = "Email adresi hatalı")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Adresi Girmelisiniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrarı Boş olamaz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}
