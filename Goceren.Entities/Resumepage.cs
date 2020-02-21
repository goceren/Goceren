using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Resumepage
    {
        public int ResumepageId { get; set; }

        [Required(ErrorMessage = "Sayfa Başlığı boş olmamalıdır.")]
        public string ResumepageTitle { get; set; }

        [Required(ErrorMessage = "Sayfa Alt Başlığı boş olmamalıdır.")]
        public string Subtitle { get; set; }
        public string CVLink { get; set; }

        [Required(ErrorMessage = "Eğitim Başlığı boş olmamalıdır.")]
        public string LeftTopTitle { get; set; }

        [Required(ErrorMessage = "Tecrübeler Başlığı boş olmamalıdır.")]
        public string LeftBottomTitle { get; set; }

        [Required(ErrorMessage = "Yetenekler Başlığı boş olmamalıdır.")]
        public string RightTopTitle { get; set; }

        public List<Education> Educations { get; set; }
        public List<Skills> Skills{ get; set; }
        public List<Experience> Experiences { get; set; }

        [Required(ErrorMessage = "Sayfa Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
