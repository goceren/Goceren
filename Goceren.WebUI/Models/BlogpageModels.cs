using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models
{
    public class BlogpageModels
    {
        public Blogpage Blogpage { get; set; }
        public List<Category> Categories{ get; set; }
        public List<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }
    }
}
