using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Goceren.DataAccessLayer.Abstract;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goceren.WebUI.Controllers
{
    public class MediumController : Controller
    {
        private readonly IMediumpageDAL _mediumpageDal;
        public MediumController(IMediumpageDAL mediumpageDal)
        {
            _mediumpageDal = mediumpageDal;
        }
        public IActionResult Index(string search)
        {
            MediumpageModels mediumpageModel = new MediumpageModels();
            List<MediumModels> mediumModel = new List<MediumModels>();
            ViewBag.search = search;
            try
            {
                mediumpageModel.Mediumpage = _mediumpageDal.GetAll().Where(i => i.isApproved == true).First();
            }
            catch (Exception)
            {
                mediumpageModel.Mediumpage = null;
            }   
            try
            {
                XNamespace content = "http://purl.org/rss/1.0/modules/content/";
                string url = "https://medium.com/feed/@" + mediumpageModel.Mediumpage.MediumUsername;
                var httpClient = new HttpClient();
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(url);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 pubDate = x.Element("pubDate").Value,
                                 content = x.Element(content + "encoded").Value,
                             });
                foreach (var item in items)
                {
                    MediumModels model = new MediumModels
                    {
                        Title = item.title,
                        Link = item.link,
                        Date = item.pubDate,
                        Content = item.content
                    };
                    mediumModel.Add(model);
                    if (!string.IsNullOrEmpty(search))
                    {
                        mediumpageModel.Medium = mediumModel.Where(i => EF.Functions.Like(i.Title, "%" + search + "%") || EF.Functions.Like(i.Content, "%" + search + "%")).ToList();
                    }
                    else
                    {
                        mediumpageModel.Medium = mediumModel;
                    }
                }
                return View(mediumpageModel);
            }
            catch (Exception)
            {
                return View(mediumpageModel);
            }
        }
        public IActionResult Detail(string title)
        {
            MediumpageModels mediumpageModels = new MediumpageModels();
            List<MediumModels> mediumModel = new List<MediumModels>();
            List<MediumCategory> blogCategory = new List<MediumCategory>();
            try
            {
                mediumpageModels.Mediumpage = _mediumpageDal.GetAll().Where(i => i.isApproved == true).FirstOrDefault();
            }
            catch (Exception)
            {

                mediumpageModels.Mediumpage = null;
            }
            try
            {
                XNamespace content = "http://purl.org/rss/1.0/modules/content/";
                string url = "https://medium.com/feed/@" + mediumpageModels.Mediumpage.MediumUsername;
                var httpClient = new HttpClient();
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(url);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 pubDate = x.Element("pubDate").Value,
                                 content = x.Element(content + "encoded").Value,
                                 categories = x.Elements("category").ToList()
                             });
                foreach (var item in items)
                {
                    MediumModels model = new MediumModels
                    {
                        Title = item.title,
                        Link = item.link,
                        Date = item.pubDate,
                        Content = item.content,
                        LinkProfile = xDoc.Descendants("link").FirstOrDefault().Value
                    };
                    foreach (var a in item.categories)
                    {
                        MediumCategory category = new MediumCategory
                        {
                            Name = a.Value
                        };
                        blogCategory.Add(category);
                    };
                    mediumpageModels.MediumCategories = blogCategory;
                    mediumModel.Add(model);
                    mediumpageModels.Medium = mediumModel.Where(i => EF.Functions.Like(i.Title, "%" + title + "%")).ToList();
                }
                //ViewBag.image = getBetween(mediumModel.Where(i => EF.Functions.Like(i.Title, "%" + title + "%")).FirstOrDefault().Content, @"src=", @"/>");
                return View(mediumpageModels);
            }
            catch (Exception)
            {
                mediumpageModels.MediumCategories = null;
                mediumModel = null;
                mediumpageModels.Medium = null;
                return View(mediumpageModels);
            }

        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}