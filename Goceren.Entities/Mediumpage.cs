using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Mediumpage
    {
        public int MediumpageId { get; set; }

        [Required(ErrorMessage = "Sayfa Başlığı boş olmamalıdır.")]
        public string PageTitle { get; set; }

        [Required(ErrorMessage = "Sayfa Alt Başlığı boş olmamalıdır.")]
        public string PageSubtitle { get; set; }

        [Required(ErrorMessage = "Medium Kullanıcı Adı boş olmamalıdır.")]
        public string MediumUsername { get; set; }

        public string BackgroundImage { get; set; }

        public string DetailImage { get; set; }

        [Required(ErrorMessage = "Sayfa Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
