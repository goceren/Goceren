using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Settings
    {
        public int SettingsId{ get; set; }

        [Required(ErrorMessage = "Site Başlığı boş olmamalıdır.")]
        public string SiteTitle{ get; set; }

        [Required(ErrorMessage = "Site AÇıklaması boş olmamalıdır.")]
        public string SiteDescription { get; set; }

        [Required(ErrorMessage = "Site Yazarı boş olmamalıdır.")]
        public string SiteAuthor { get; set; }

        [Required(ErrorMessage = "Site Anahtar Kelimeler boş olmamalıdır.")]
        public string SiteKeywords { get; set; }
        public string SiteIcon { get; set; }

        [Required(ErrorMessage = "Ayarlar Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
