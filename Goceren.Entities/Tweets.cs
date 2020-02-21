using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Tweets
    {
        public int TweetsId { get; set; }

        [Required(ErrorMessage = "Consumer Key boş olmamalıdır.")]
        public string ConsumerKey { get; set; }

        [Required(ErrorMessage = "Consumer Secret boş olmamalıdır.")]
        public string ConsumerSecret { get; set; }

        [Required(ErrorMessage = "Access Token boş olmamalıdır.")]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = "Access Token Secret boş olmamalıdır.")]
        public string AccessTokenSecret { get; set; }

        [Required(ErrorMessage = "Başlık boş olmamalıdır.")]
        public string FeedTitle { get; set; }

        [Required(ErrorMessage = "Twitter Kullanıcı Adı boş olmamalıdır.")]
        public string TwitterUsername { get; set; }

        [Required(ErrorMessage = "Aktiflik boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
