using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori Adı boş olmamalıdır")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Kategori Tipi boş olmamalıdır")]
        public string CategoryType { get; set; }

        [Required(ErrorMessage = "Kategori Aktifliği boş olmamalıdır")]
        public bool isApproved { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }

    }
}
