using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class Skills
    {
        public int SkillsId { get; set; }
        public int? ResumepageId { get; set; }
        public Resumepage Resumepage { get; set; }

        [Required(ErrorMessage = "Yetenek Başlığı boş olmamalıdır.")]
        public string SkillTitle { get; set; }

        [Required(ErrorMessage = "Yeteneek Yüzdesi boş olmamalıdır.")]
        public string SkillPercent { get; set; }

        [Required(ErrorMessage = "Yetenek Onayı boş olmamalıdır.")]
        public bool isApproved { get; set; }
    }
}
