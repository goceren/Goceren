using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Blog Başlığı boş olmamalıdır")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Blog içeriği boş olmamalıdır")]
        public string BlogContent { get; set; }

        [Required(ErrorMessage = "Blog Başlığı boş olmamalıdır")]
        public string BlogAuthor { get; set; }

        [Required(ErrorMessage = "Blog Tarihi boş olmamalıdır")]
        public DateTime BlogDate { get; set; }

        public int ViewCount{ get; set; }

        public List<BlogCategory> BlogCategories { get; set; }

        [Required(ErrorMessage = "Blog durumu boş olmamalıdır")]
        public bool isPublished { get; set; }
        [Required]
        public bool BlogUser { get; set; }
        [Required]
        public bool BlogConfirm { get; set; }
        public bool SawAdmin { get; set; }
        public string BlogViewImage { get; set; }

        public string BlogDetailImage { get; set; }

    }
}
