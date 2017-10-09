using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class MarvelResultVM
    {
        [Required]
        [StringLength(15, ErrorMessage = "Enter a name between 3 and 15 characters", MinimumLength = 3)]
        [DisplayName("Character Name")]
        public string SearchName { get; set; }

        public MarvelResult SearchResults { get; set; }
    }
}