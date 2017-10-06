using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TractorAPI.Models
{
    public class UpdateTractorRequest
    {
        [Required]
        public int updateID { get; set; }
        [Required]
        [DisplayName("Tractor Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Tractor Driver")]
        public string Driver { get; set; }
        public string TClass { get; set; }

    }
}