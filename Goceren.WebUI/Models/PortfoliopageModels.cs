using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models
{
    public class PortfoliopageModels
    {
        public Portfoliopage Portfoliopage { get; set; }
        public List<Category> Categories { get; set; }
        public List<GithubRepoModels> GithubRepoModels { get; set; }

    }
}
