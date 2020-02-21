using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class WhatIDo
    {
        public int WhatIDoId { get; set; }

        [Required(ErrorMessage = "What I Do Başlığı boş olmamalıdır.")]
        public string WhatIDoTitle { get; set; }

        [Required(ErrorMessage = "Başlık boş olmamalıdır.")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Açıklama boş olmamalıdır.")]
        public string Description1 { get; set; }

        [Required(ErrorMessage = "Başlık boş olmamalıdır.")]
        public string Title2 { get; set; }

        [Required(ErrorMessage = "Açıklama boş olmamalıdır.")]
        public string Description2 { get; set; }

        [Required(ErrorMessage = "Aktiflik boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
