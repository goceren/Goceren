using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public int? ResumepageId { get; set; }
        public Resumepage Resumepage { get; set; }

        [Required(ErrorMessage = "Tecrübe Tarihi boş olmamalıdır")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Tecrübe Başlığı boş olmamalıdır")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Tecrübe Açıklaması boş olmamalıdır")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Şirket Adı boş olmamalıdır")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Tecrübe Aktifliği boş olmamalıdır")]
        public bool isApproved { get; set; }
    }
}
