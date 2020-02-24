using System;
using System.ComponentModel.DataAnnotations;

namespace Goceren.WebUI.Models.AdminModels
{
    public class UserModel
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public bool Confirmed { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
