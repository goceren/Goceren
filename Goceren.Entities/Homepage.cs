using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Homepage
    {
        public int HomepageId { get; set; }

        [Required(ErrorMessage = "Anasayfa Adı boş olmamalıdır.")]
        public string Title { get; set; }
        public List<HomeSubtitle> HomeSubtitle { get; set; }

        public string AboutImage { get; set; }

        [Required(ErrorMessage = "Anasayfa Hakkımda üst kısım boş olmamalıdır.")]
        public string AboutTop { get; set; }

        [Required(ErrorMessage = "Anasayfa Hakkımda alt kısım boş olmamalıdır.")]
        public string AboutBottom { get; set; }

        public string CVLink { get; set; }

        [Required(ErrorMessage = "Anasayfa Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
