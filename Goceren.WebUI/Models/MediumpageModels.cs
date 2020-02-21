using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Models
{
    public class MediumpageModels
    {
        public Mediumpage Mediumpage { get; set; }
        public List<MediumModels> Medium { get; set; }
        public List<MediumCategory> MediumCategories { get; set; }
    }
}
