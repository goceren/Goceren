using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;
using Goceren.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Goceren.WebUI.Controllers
{
    [Produces("application/xml")]
    public class RSSController : Controller
    {
        private readonly IBlogService _blogService;
        public RSSController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [Route("/rss")]
        public IActionResult Index()
        {
            XNamespace ns = "http://www.w3.org/2005/Atom";
            var rss = new XElement("rss", new XAttribute("version", "2.0"), new XAttribute(XNamespace.Xmlns + "atom", ns));
            var channel = new XElement("channel",
                new XElement("title", "goceren.com"),
                new XElement("link", "https://www.goceren.com"),
                new XElement("description", "About programming and software engineering"),
                new XElement("language", "tr"),
                //todo: add blogChannel tags
                new XElement("copyright", $"Copyright {DateTime.UtcNow.Year} Veli Yavuz Göçeren"),
                new XElement("lastBuildDate", _blogService.GetAll().OrderByDescending(n => n.BlogDate).First().BlogDate.ToUniversalTime().ToString("r")),
                new XElement("category", "Software Engineering"),
                new XElement(ns + "link", new XAttribute("href", "https://goceren.com/Rss"), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")),
                new XElement("image",
                             new XElement("url", "https://goceren.com/Site/img/yavuzprofile.jpg"),
                             new XElement("title", "goceren.com"),
                             new XElement("link", "https://www.goceren.com")
                            ),
                new XElement("ttl", "40")
             );

            foreach (var post in _blogService.GetAll().Where(i => i.isPublished && i.BlogConfirm))
            {
                var postInRss = new XElement("item");
                postInRss.Add(new XElement("title", post.BlogTitle));
                postInRss.Add(new XElement("description", post.BlogContent));
                postInRss.Add(new XElement("link", "https://goceren.com/blog/Detail?BlogId=" + post.BlogId));
                postInRss.Add(new XElement("author", "yavuz@goceren.com (Veli Yavuz Göçeren)"));
                postInRss.Add(new XElement("pubDate", post.BlogDate.ToUniversalTime().ToString("r")));
                channel.Add(postInRss);
            }
            rss.Add(channel);
            return Ok(rss);
        }
    }
}