using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models.AdminModels
{
    public class SubtitleAdminModels
    {
        public int SubtitleId { get; set; }
        [Required(ErrorMessage = "Alt Başlık Adı Boş olamaz")]
        public string SubtitleName { get; set; }
        [Required(ErrorMessage = "Alt Başlık Aktifliği Boş olamaz")]
        public Boolean isApproved { get; set; }
        public List<Homepage> Homepage { get; set; }
    }
}
