using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class BlogCategory
    {
        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
    }
}
