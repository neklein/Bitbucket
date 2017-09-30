using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TractorFanSite.Models
{
    public class Tractor
    {
        [DisplayName ("Tractor Name")]
        public string Name { get; set; }
        [DisplayName("Tractor Class")]
        public string TractorClass { get; set; }
        [DisplayName("Driver Name")]
        public string Driver { get; set; }
        public string TractorImage { get; set; }

    }
}