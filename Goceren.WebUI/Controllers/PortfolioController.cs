using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octokit;

namespace Goceren.WebUI.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfoliopageService _portfoliopageService;
        private readonly ICategoryService _categoryService;
        public PortfolioController(IPortfoliopageService portfoliopageService, ICategoryService categoryService)
        {
            _portfoliopageService = portfoliopageService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> IndexAsync(string search)
        {
            PortfoliopageModels portfoliopageModel = new PortfoliopageModels();
            List<GithubRepoModels> githubModel = new List<GithubRepoModels>();
            try
            {
                portfoliopageModel.Portfoliopage = _portfoliopageService.GetAll().Where(i => i.isApproved == true).First();

            }
            catch (Exception)
            {
                portfoliopageModel.Portfoliopage = null;
            }
            portfoliopageModel.Categories = _categoryService.GetAll().Where(i => i.isApproved == true && i.CategoryType == "Github").ToList();
            ViewBag.search = search;
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
                var user = await client.Repository.GetAllForUser(portfoliopageModel.Portfoliopage.GithubUsername);
                foreach (var item in user)
                {
                    GithubRepoModels repos = new GithubRepoModels
                    {
                        CreatedAt = item.CreatedAt.Date.ToString(),
                        Language = item.Language,
                        Description = item.Description,
                        HtmlUrl = item.HtmlUrl,
                        Name = item.Name,
                    };
                    githubModel.Add(repos);
                    if (!string.IsNullOrEmpty(search))
                    {
                        portfoliopageModel.GithubRepoModels = githubModel.Where(i => EF.Functions.Like(i.Name, "%" + search + "%") || EF.Functions.Like(i.Description, "%" + search + "%") || EF.Functions.Like(i.Language, "%" + search + "%")).ToList();
                    }
                    else
                    {
                        portfoliopageModel.GithubRepoModels = githubModel;
                    }
                }
                return View(portfoliopageModel);
            }
            catch (Exception)
            {
                return View(portfoliopageModel);
            }
        }
    }
}