using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Goceren.Entities
{
    public class HomeSubtitle
    {
        [Required]
        public int HomepageId { get; set; }
        public Homepage Homepage { get; set; }

        [Required]
        public int SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
    }
}
