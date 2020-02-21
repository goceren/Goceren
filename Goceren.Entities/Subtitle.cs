using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Subtitle
    {
        public int SubtitleId { get; set; }

        [Required(ErrorMessage = "Alt başlık Adı boş olmamalıdır.")]
        public string SubtitleName { get; set; }
        public List<HomeSubtitle> HomeSubtitle { get; set; }

        [Required(ErrorMessage = "Alt Başlık Aktifliği boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
