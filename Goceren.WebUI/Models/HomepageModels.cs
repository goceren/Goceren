using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models
{
    public class HomepageModels
    {
        public Homepage Homepage { get; set; }
        public List<Subtitle> Subtitle { get; set; }
        public List<WhatIDo> WhatIDo { get; set; }
        public Tweets Tweets { get; set; }
        public TwitterModel TwitterModel { get; set; }
        public List<TweetsModel> TweetsModel { get; set; }
    }
}
