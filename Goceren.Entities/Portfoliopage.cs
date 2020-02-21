using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Portfoliopage
    {
        public int PortfoliopageId { get; set; }

        [Required(ErrorMessage = "Sayfa Başlığı boş olmamalıdır.")]
        public string PageTitle { get; set; }

        [Required(ErrorMessage = "Sayfa Alt Başlığı boş olmamalıdır.")]
        public string PageSubtitle { get; set; }

        [Required(ErrorMessage = "Github Kullanıcı Adı boş olmamalıdır.")]
        public string GithubUsername { get; set; }
        public string BackgroundImage { get; set; }

        [Required(ErrorMessage = "Sayfa Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }

    }
}
