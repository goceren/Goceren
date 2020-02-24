using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models.AdminModels
{
    public class ChangeEmailModel
    {
        [Required(ErrorMessage = "Boş Olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
