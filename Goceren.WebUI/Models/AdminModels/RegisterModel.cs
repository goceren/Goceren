using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models.AdminModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Boş olamaz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Boş olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Boş olamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email olmalıdır.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş olamaz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
