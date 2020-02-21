using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class MenuType
    {
        public int MenuTypeId { get; set; }
        [Required(ErrorMessage = "Menü Tipi Adı boş olmamalıdır.")]
        public string MenuTypeName { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
