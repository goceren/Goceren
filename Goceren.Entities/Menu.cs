using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Menü Adı boş olmamalıdır.")]
        public string MenuName { get; set; }

        [Required(ErrorMessage = "Menü Linki boş olmamalıdır.")]
        public string MenuLink { get; set; }

        [Required(ErrorMessage = "Menu Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
        public int? MenuTypeId { get; set; }
        public MenuType MenuType { get; set; }
    }
}
