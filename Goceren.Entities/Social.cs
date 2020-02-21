using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Social
    {
        public int SocialId { get; set; }

        [Required(ErrorMessage = "Facebook Linki boş olmamalıdır.")]
        public string FacebookLink { get; set; }

        [Required(ErrorMessage = "Twitter Linki boş olmamalıdır.")]
        public string TwitterLink { get; set; }

        [Required(ErrorMessage = "İnstagram Linki boş olmamalıdır.")]
        public string InstagramLink { get; set; }

        [Required(ErrorMessage = "Linkedin Linki boş olmamalıdır.")]
        public string LinkedinLink { get; set; }

        [Required(ErrorMessage = "Github Linki boş olmamalıdır.")]
        public string GithubLink { get; set; }

        [Required(ErrorMessage = "Medium Linki boş olmamalıdır.")]
        public string MediumLink { get; set; }

        [Required(ErrorMessage = "Email Linki boş olmamalıdır.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sosyal Medya Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
