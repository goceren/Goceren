using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models
{
    public class NavbarModels
    {
        public Navbar Navbar { get; set; }
        public List<Menu> Menu { get; set; }
        public Social Social { get; set; }
    }
}
