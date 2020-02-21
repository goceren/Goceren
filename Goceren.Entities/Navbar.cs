using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Navbar
    {
        public int NavbarId { get; set; }

        [Required(ErrorMessage = "Navbar Başlığı boş olmamalıdır.")]
        public string NavbarTitle { get; set; }

        public string NavbarImage { get; set; }

        [Required(ErrorMessage = "Copyright boş olmamalıdır.")]
        public string Cpyright { get; set; }

        [Required(ErrorMessage = "Navbar Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
