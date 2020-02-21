using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Blogpage
    {
        public int BlogpageId { get; set; }
        [Required(ErrorMessage = "Blog Sayfa Başlığı boş olmamalıdır")]
        public string PageTitle { get; set; }

        [Required(ErrorMessage = "Blog Sayfa Alt Başlığı boş olmamalıdır")]
        public string PageSubtitle { get; set; }

        [Required(ErrorMessage = "Blog Sayfa Aktifliği boş olmamalıdır")]
        public bool isApproved { get; set; }
    }
}
