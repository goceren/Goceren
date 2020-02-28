using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goceren.Business.Abstract;
using Goceren.Entities;
using Goceren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Goceren.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomepageService _homepageService;
        private readonly ISubtitleService _subtitleService;
        private readonly IWhatIDoService _whatIDoService;
        private readonly ITweetsService _tweetsService;
        private readonly IViewersService _viewersService;
        public HomeController(IHomepageService homepageService, ISubtitleService subtitleService, IWhatIDoService whatIDoService, ITweetsService tweetsService, IViewersService viewersService)
        {
            _homepageService = homepageService;
            _subtitleService = subtitleService;
            _whatIDoService = whatIDoService;
            _tweetsService = tweetsService;
            _viewersService = viewersService;
        }
        public IActionResult Index()
        {
            try
            {
                var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                var arti = Request.HttpContext.Connection.RemotePort.ToString();
                var clientDetails = ip + ":" + arti;
                if (!_viewersService.GetAll().Any(i => i.ViewBlog == -1 && i.IP == clientDetails && i.Date.Contains(DateTime.Now.Date.ToString())))
                {
                    _viewersService.Create(new Viewers() { IP = clientDetails, ViewBlog = -1, Date = DateTime.Now.Date.ToString()});
                }
            }
            catch (Exception)
            {
            }
            HomepageModels model = new HomepageModels();
            List<TweetsModel> tweetsModel = new List<TweetsModel>();
            try
            {
                model.Homepage = _homepageService.GetAll().Where(i => i.isApproved == true).First();
                try
                {
                    model.Subtitle = _subtitleService.GetSubtitleByHome(model.Homepage.HomepageId).Where(i => i.isApproved).ToList();
                }
                catch (Exception)
                {
                    model.Subtitle = null;
                }
            }
            catch (Exception)
            {

                model.Homepage = null;
            }

            model.WhatIDo = _whatIDoService.GetAll().Where(i => i.isApproved).Take(2).ToList();
            try
            {
                model.Tweets = _tweetsService.GetAll().Where(i => i.isApproved == true).First();
                Auth.SetUserCredentials(model.Tweets.ConsumerKey.Trim(), model.Tweets.ConsumerSecret.Trim(), model.Tweets.AccessToken.Trim(), model.Tweets.AccessTokenSecret.Trim());
                var user = Tweetinvi.User.GetAuthenticatedUser();
                var userIdentifier = new UserIdentifier(model.Tweets.TwitterUsername.Trim());
                var userTimelineParameters = new UserTimelineParameters { MaximumNumberOfTweetsToRetrieve = 11 };
                var tweets = Timeline.GetUserTimeline(userIdentifier, userTimelineParameters);
                TwitterModel twModel = new TwitterModel
                {
                    Name = user.Name,
                    SceenName = user.ScreenName,
                    ProfileImage = user.ProfileImageUrlHttps,
                    Follower = user.FollowersCount.ToString(),
                };
                model.TwitterModel = twModel;
                foreach (var item in tweets)
                {
                    TweetsModel tweet = new TweetsModel
                    {
                        Id = item.Id.ToString(),
                        Text = item.FullText,
                        CreatedDate = item.TweetLocalCreationDate.ToString(),
                        LikeCount = item.FavoriteCount.ToString()
                    };
                    tweetsModel.Add(tweet);
                    model.TweetsModel = tweetsModel;
                }
                return View(model);
            }
            catch (Exception)
            {
                model.TweetsModel = null;
                return View(model);
            }

        }

    }
}