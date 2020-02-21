using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Education
    {
        public int EducationId { get; set; }
        public int? ResumepageId { get; set; }
        public Resumepage Resumepage { get; set; }

        [Required(ErrorMessage = "Eğitim Tarihi boş olmamalıdır")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Eğitim Başlığı boş olmamalıdır")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Eğitim Açıklaması boş olmamalıdır")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Eğitim Tipi boş olmamalıdır")]
        public string EducationType { get; set; }

        [Required(ErrorMessage = "Eğitim Aktifliği boş olmamalıdır")]
        public bool isApproved { get; set; }

    }
}
