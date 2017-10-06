using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TractorAPI.Models
{
    public class Tractor
    {
        public int TractorID { get; set; }
        public string TractorName { get; set; }
        public string TractorDriver { get; set; }
        public string TractorClass { get; set; }
    }
}